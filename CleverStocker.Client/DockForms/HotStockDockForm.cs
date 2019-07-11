using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Model.Comparers;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 热门股票窗口
    /// </summary>
    public partial class HotStockDockForm : SingleToolDockForm
    {
        #region 服务

        /// <summary>
        /// 股票比较器
        /// </summary>
        private readonly StockBaseComparer<Stock> stockComparer = new StockBaseComparer<Stock>();

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 爬虫服务
        /// </summary>
        protected IStockSpiderService StockSpiderService { get; set; }
        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        public string SourceName { get; set; } = typeof(HotStockDockForm).Name;

        private Stock currentStock;

        /// <summary>
        /// Gets or sets 当前选中的股票
        /// </summary>
        /// <remarks>应注意减少频繁发送重复的消息</remarks>
        public Stock CurrentStock
        {
            get => this.currentStock;
            protected set
            {
                if (this.currentStock == value)
                {
                    return;
                }

                this.currentStock = value;

                if (value == null)
                {
                    this.RemoveToolButton.Enabled = false;
                }
                else
                {
                    this.RemoveToolButton.Enabled = true;
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="HotStockDockForm"/> class.
        /// </summary>
        public HotStockDockForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.HotIcon;
        }

        private void HotStockDockForm_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.StockService = DIContainerHelper.Resolve<IStockService>();
            this.StockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
        }

        private void HotStockDockForm_Shown(object sender, System.EventArgs e)
        {
            _ = this.RefreshDataSource();
        }
        #endregion

        #region 主题

        /// <summary>
        /// 应用主题
        /// </summary>
        public override void ApplyTheme()
        {
            base.ApplyTheme();

            // 配置数据单元格样式：DataGridView.RowTemplate.DefaultCellStyle
            this.HotStocksGridView.BackgroundColor = this.BackColor;
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.ForeColor = ThemeHelper.GetContentForecolor();
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = ThemeHelper.GetContentHighLightBackcolor();
            this.HotStocksGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = ThemeHelper.GetContentHighLightForecolor();

            /* 配置标题单元格样式：DataGridView.ColumnHeadersDefaultCellStyle
             * < DataGridView 需要关闭此设置才可以应用样式 >
             */
            this.HotStocksGridView.EnableHeadersVisualStyles = false;
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeHelper.GetTitleBackcolor();
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.ForeColor = ThemeHelper.GetTitleForecolor();
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.HotStocksGridView.ColumnHeadersDefaultCellStyle.BackColor;
            this.HotStocksGridView.ColumnHeadersDefaultCellStyle.Font = new Font(this.HotStocksGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Regular);
        }
        #endregion

        #region 控件

        private void HotStocksGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            this.CurrentStock = this.HotStocksGridView.CurrentRow?.DataBoundItem as Stock;
        }

        private void AddToolButton_Click(object sender, System.EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectAdd, this.currentStock.GetFullCode());
        }

        private void RemoveToolButton_Click(object sender, System.EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            MQHelper.Publish(this.SourceName, MQTopics.TopicStockSelfSelectRemove, this.currentStock.GetFullCode());
        }

        private void RefreshToolButton_Click(object sender, System.EventArgs e)
        {
            _ = this.RefreshDataSource();
        }
        #endregion

        #region 功能

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private async Task RefreshDataSource()
        {
            this.HotStockBindingSource.DataSource = await this.StockSpiderService.GetHotStocksAsync();
        }
        #endregion
    }
}
