using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 自选股票窗口
    /// </summary>
    public partial class SelfSelectStockForm : ToolDockForm
    {
        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfSelectStockForm"/> class.
        /// </summary>
        public SelfSelectStockForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.SelfSelectIcon;
            this.HideOnClose = true;
        }

        private void SelfSelectStockForm_Load(object sender, System.EventArgs e)
        {
            this.StockService = DIContainerHelper.Resolve<IStockService>();

            this.stockBindingSource.DataSource = this.StockService.GetSelfSelectStocks();
        }
    }
}
