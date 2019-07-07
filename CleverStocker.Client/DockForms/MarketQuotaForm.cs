namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 大盘指数
    /// </summary>
    public partial class MarketQuotaForm : SingleToolDockForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuotaForm"/> class.
        /// </summary>
        public MarketQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.MarketQuotaIcon;
        }

        #region 控件

        private void AutoRefreshToolButton_CheckedChanged(object sender, System.EventArgs e)
        {
        }

        private void RefreshToolButton_Click(object sender, System.EventArgs e)
        {
        }

        private void MarketQuotaRepositoryToolButton_Click(object sender, System.EventArgs e)
        {
        }
        #endregion
    }
}
