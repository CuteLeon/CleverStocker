namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 单实例工具窗口
    /// </summary>
    public partial class SingleToolDockForm : ToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleToolDockForm"/> class.
        /// </summary>
        public SingleToolDockForm()
            : base()
        {
            this.InitializeComponent();

            // 单实例工具窗口需要避免被释放
            this.HideOnClose = true;
        }
    }
}
