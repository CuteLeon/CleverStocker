using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 工具停靠窗口
    /// </summary>
    public partial class ToolDockForm : DockFormBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolDockForm"/> class.
        /// </summary>
        public ToolDockForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets 默认停靠区域
        /// </summary>
        public override DockAreas DefaultDockAreas { get; set; } = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockLeft;
    }
}
