namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public partial class CompanyInfoForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyInfoForm"/> class.
        /// </summary>
        public CompanyInfoForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.CompanyInfoIcon;
        }
    }
}
