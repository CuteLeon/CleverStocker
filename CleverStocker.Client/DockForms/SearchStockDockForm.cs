using System;
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
        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        public string SourceName { get; set; } = typeof(SearchStockDockForm).Name;

        /// <summary>
        /// Gets or sets 布局持久化数据
        /// </summary>
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
        public Stock CurrentStock
        {
            get => this.currentStock;
            protected set
            {
                this.currentStock = value;
                this.DataToFace(value);
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

        private void SaveToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            this.StockService.AddOrUpdate(this.currentStock);
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
            var (stock, _) = await this.StockSpiderService.GetStockQuotaAsync(code, market);
            this.CurrentStock = stock;
        }

        /// <summary>
        /// 应用数据到界面
        /// </summary>
        /// <param name="stock"></param>
        private void DataToFace(Stock stock)
        {
            if (stock == null)
            {
                this.SearchToolStrip.Enabled = false;
            }
            else
            {
                this.SearchToolStrip.Enabled = true;
            }
        }
        #endregion
    }
}
