using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
using static WeifenLuo.WinFormsUI.Docking.DockPanelExtender;

namespace CleverStocker.Client.DockForms.FloatWindows
{
    /// <summary>
    /// 浮动窗口工厂
    /// </summary>
    public class FloatedWindowFactory : IFloatWindowFactory
    {
        /// <summary>
        /// Gets 唯一实例
        /// </summary>
        public static FloatedWindowFactory SingleInstance { get; } = new FloatedWindowFactory();

        /// <summary>
        /// 创建浮动窗口
        /// </summary>
        /// <param name="dockPanel"></param>
        /// <param name="pane"></param>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
            => new FloatedWindow(dockPanel, pane, bounds);

        /// <summary>
        /// 创建浮动窗口
        /// </summary>
        /// <param name="dockPanel"></param>
        /// <param name="pane"></param>
        /// <returns></returns>
        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
            => new FloatedWindow(dockPanel, pane);
    }
}
