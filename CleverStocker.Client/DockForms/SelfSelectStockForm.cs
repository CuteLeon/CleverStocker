using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 自选股票窗口
    /// </summary>
    public partial class SelfSelectStockForm : DockFormBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelfSelectStockForm"/> class.
        /// </summary>
        public SelfSelectStockForm()
        {
            this.InitializeComponent();

            this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
            this.ShowHint = DockState.DockLeft;
            this.HideOnClose = true;
        }
    }
}
