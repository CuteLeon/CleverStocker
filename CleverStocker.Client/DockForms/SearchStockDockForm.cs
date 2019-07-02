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
        /// Gets or sets mQ 订阅者
        /// </summary>
        public SubscriberHandler Subscriber { get; set; }

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
        public string SourceName { get; set; } = typeof(SelfSelectStockForm).Name;

        /// <summary>
        /// Gets or sets 交易市场
        /// </summary>
        public Markets Market { get; set; }

        /// <summary>
        /// Gets or sets 股票代码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchStockDockForm"/> class.
        /// </summary>
        public SearchStockDockForm()
        {
            this.InitializeComponent();
        }
        #endregion
    }
}
