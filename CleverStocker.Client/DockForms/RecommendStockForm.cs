using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 推荐股票窗口
    /// </summary>
    public partial class RecommendStockForm : DockFormBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendStockForm"/> class.
        /// </summary>
        public RecommendStockForm()
            : base()
        {
            this.InitializeComponent();

            this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
            this.ShowHint = DockState.DockLeft;
            this.HideOnClose = true;
        }
    }
}
