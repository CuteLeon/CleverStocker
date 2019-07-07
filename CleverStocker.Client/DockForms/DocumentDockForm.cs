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
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.DocumentIcon;
        }
    }
}
