using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 最近交易
    /// </summary>
    public partial class RecentTradeForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentTradeForm"/> class.
        /// </summary>
        public RecentTradeForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.RecentTradeIcon;
        }

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockRight;
    }
}
