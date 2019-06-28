namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 推荐股票窗口
    /// </summary>
    public partial class RecommendStockForm : ToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendStockForm"/> class.
        /// </summary>
        public RecommendStockForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.RecommendStockIcon;
            this.HideOnClose = true;
        }
    }
}
