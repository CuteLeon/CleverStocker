using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 停靠窗口基类
    /// </summary>
    public abstract class DockFormBase : DockContent
    {
        /// <summary>
        /// Gets or sets 标题
        /// </summary>
        public override string Text
        {
            get => base.Text;

            set
            {
                base.Text = value;
                this.TabText = value;
            }
        }
    }
}
