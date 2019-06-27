using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CleverStocker.Client.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 停靠窗口基类
    /// </summary>
    /// <see cref="http://docs.dockpanelsuite.com/getting-started/index.html#"/>
    public class DockFormBase : DockContent, IInitializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DockFormBase"/> class.
        /// </summary>
        public DockFormBase()
            : base()
        {
            this.BackColor = Color.FromArgb(37, 37, 38);
        }

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

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<string> Initialize()
        {
            yield break;
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>坑：this.Hide() 将引用到 DockContent().Hide()，请使用：((Form)this).Hide() 或 this.Visible = false</remarks>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 如果启用“隐藏窗口而非关闭”且用户主动请求关闭时
            if (this.HideOnClose &&
                e.CloseReason == CloseReason.UserClosing)
            {
                // 取消窗口关闭并手动隐藏窗口
                e.Cancel = true;
                this.Visible = false;
            }

            base.OnFormClosing(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DockFormBase
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "DockFormBase";
            this.ResumeLayout(false);

        }
    }
}
