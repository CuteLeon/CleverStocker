using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 最近行情
    /// </summary>
    public partial class RecentQuotaForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuotaForm"/> class.
        /// </summary>
        public RecentQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.RecentQuotaIcon;
        }

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockRight;
    }
}
