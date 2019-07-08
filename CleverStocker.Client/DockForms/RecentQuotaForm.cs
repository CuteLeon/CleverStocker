namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 最近行情
    /// </summary>
    public partial class RecentQuotaForm : SingleToolDockForm //, IMQPubsubable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuotaForm"/> class.
        /// </summary>
        public RecentQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.RecentQuotaIcon;
        }
    }
}
