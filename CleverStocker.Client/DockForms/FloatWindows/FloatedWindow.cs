using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms.FloatWindows
{
    /// <summary>
    /// 浮动窗口
    /// </summary>
    public class FloatedWindow : FloatWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloatedWindow"/> class.
        /// </summary>
        /// <param name="dockPanel"></param>
        /// <param name="pane"></param>
        public FloatedWindow(DockPanel dockPanel, DockPane pane)
            : base(dockPanel, pane)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatedWindow"/> class.
        /// </summary>
        /// <param name="dockPanel"></param>
        /// <param name="pane"></param>
        /// <param name="bounds"></param>
        public FloatedWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
            : base(dockPanel, pane, bounds)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
