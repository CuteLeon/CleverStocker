using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 文档停靠窗口
    /// </summary>
    public partial class DocumentDockForm : DockFormBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDockForm"/> class.
        /// </summary>
        public DocumentDockForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.DocumentIcon;
        }

        /// <summary>
        /// Gets or sets 默认停靠区域
        /// </summary>
        public override DockAreas DefaultDockAreas { get; set; } = DockAreas.Float | DockAreas.Document;

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.Document;
    }
}
