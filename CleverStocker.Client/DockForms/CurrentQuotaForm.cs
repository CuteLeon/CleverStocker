using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 实时行情
    /// </summary>
    public partial class CurrentQuotaForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentQuotaForm"/> class.
        /// </summary>
        public CurrentQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.CurrentQuotaIcon;
            this.HideOnClose = true;
            this.CloseButton = false;
            this.CloseButtonVisible = false;
        }

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockRight;
    }
}
