using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 大盘指数
    /// </summary>
    public partial class MarketQuotaForm : ToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuotaForm"/> class.
        /// </summary>
        public MarketQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.MarketQuotaIcon;
        }

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockRight;
    }
}
