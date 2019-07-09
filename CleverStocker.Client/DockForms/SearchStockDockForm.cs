using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client.DockForms
{
    // TODO: 股票相关功能按钮加入到搜索窗口工具栏

    /// <summary>
    /// 搜索股票窗口
    /// </summary>
    public partial class SearchStockDockForm : ToolDockForm
    {
        #region 服务

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 股票爬虫服务
        /// </summary>
        protected IStockSpiderService StockSpiderService { get; set; }

        /// <summary>
        /// Gets or sets 行情服务
        /// </summary>
        protected IQuotaService QuotaService { get; set; }
        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SourceName { get; set; } = typeof(SearchStockDockForm).Name;

        /// <summary>
        /// Gets or sets 布局持久化数据
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string PersistValue
        {
            get => this.currentStock?.GetFullCode();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                var (code, market, _) = value.GetMarketCode();
                this.CodeTextBox.Text = code;
                this.MarketComboBox.SelectedItem = market.ToString();
            }
        }

        private Stock currentStock;

        /// <summary>
        /// Gets or sets 当前股票
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Stock CurrentStock
        {
            get => this.currentStock;
            protected set
            {
                this.currentStock = value;

                this.SearchToolStrip.Enabled = value != null;
                this.MainStockQuotaControl.Stock = value;
            }
        }

        private Quota currentQuota;

        /// <summary>
        /// Gets or sets 当前行情
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Quota CurrentQuota
        {
            get => this.currentQuota;
            protected set
            {
                this.currentQuota = value;
                this.MainStockQuotaControl.AttachEntity = value;
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchStockDockForm"/> class.
        /// </summary>
        public SearchStockDockForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.SearchIcon;
            this.MarketComboBox.Items.AddRange(Enum.GetNames(typeof(Markets)));
        }

        private void SearchStockDockForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.StockService = DIContainerHelper.Resolve<IStockService>();
            this.StockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            this.QuotaService = DIContainerHelper.Resolve<IQuotaService>();
        }
        #endregion

        #region 主题

        /// <summary>
        /// 应用主题
        /// </summary>
        public override void ApplyTheme()
        {
            base.ApplyTheme();

            ThemeHelper.CurrentThemeComponent.ApplyTo(this.SearchToolStrip);
            this.CodeLabel.ForeColor = ThemeHelper.GetTitleForecolor();
            this.MarketLabel.ForeColor = this.CodeLabel.ForeColor;
            this.MarketComboBox.BackColor = this.BackColor;
            this.MarketComboBox.ForeColor = ThemeHelper.GetContentForecolor();
            this.CodeTextBox.BackColor = this.BackColor;
            this.CodeTextBox.ForeColor = this.MarketComboBox.ForeColor;
            this.SearchButton.BackColor = ThemeHelper.GetTitleBackcolor();
            this.SearchButton.ForeColor = this.MarketComboBox.ForeColor;

            this.MainStockQuotaControl.LabelForecolor = this.CodeLabel.ForeColor;
            this.MainStockQuotaControl.ValueForecolor = this.CodeTextBox.ForeColor;
        }
        #endregion

        #region 控件

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string code = this.CodeTextBox.Text;
            Markets market = ConverterHelper.StringToEnum(this.MarketComboBox.Text, Markets.Unknown);

            if (string.IsNullOrWhiteSpace(code) ||
                market == Markets.Unknown)
            {
                MessageBox.Show("请输入有效的股票代码和交易市场！", "数据有误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ = this.SearchStock(code, market);
        }

        private void AddSelfSelectToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectAdd, this.currentStock.GetFullCode());
        }

        private void RemoveSelfSelectToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectRemove, this.currentStock.GetFullCode());
        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            _ = this.SearchStock(this.currentStock.Code, this.currentStock.Market);
        }

        private void ChartToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var form = DIContainerHelper.Resolve<ChartDocumentForm>();
            if (form == null)
            {
                return;
            }

            form.Stock = this.currentStock;
            form.Show(this.DockPanel);
        }

        private void QuotaRepositoryToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var form = DIContainerHelper.Resolve<QuotaRepositoryDocumentForm>();
            if (form == null)
            {
                return;
            }

            form.Stock = this.currentStock;
            form.Show(this.DockPanel);
        }

        private void SaveToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock != null)
            {
                this.StockService.AddOrUpdate(this.currentStock);
            }

            if (this.currentQuota != null)
            {
                this.QuotaService.AddOrUpdate(this.currentQuota);
            }
        }

        private void DeleteToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var stock = this.StockService.Find(this.currentStock.Code, this.currentStock.Market);
            if (stock != null)
            {
                this.StockService.Remove(stock);
                MQHelper.Publish(this.SourceName, MQTopics.TopicStockRemove, stock.GetFullCode());
            }
        }

        private void RecentToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var form = DIContainerHelper.Resolve<RecentQuotaDocumentForm>();
            if (form == null)
            {
                return;
            }

            form.Stock = this.currentStock;
            form.Show(this.DockPanel);
        }
        #endregion

        #region 功能

        /// <summary>
        /// 搜索股票
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task SearchStock(string code, Markets market)
        {
            var (stock, quota) = await this.StockSpiderService.GetStockQuotaAsync(code, market);

            this.CurrentStock = stock;
            this.CurrentQuota = quota;
        }
        #endregion
    }
}
