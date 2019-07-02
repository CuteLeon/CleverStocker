namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 所有股票窗口
    /// </summary>
    public partial class AllStockForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllStockForm"/> class.
        /// </summary>
        public AllStockForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.AllStockIcon;
        }
    }
}
