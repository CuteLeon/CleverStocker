using System.Windows.Forms;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 行情仓库停靠窗口
    /// </summary>
    public partial class QuotaRepositoryDockForm : DocumentDockForm
    {
        #region 服务

        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotaRepositoryDockForm"/> class.
        /// </summary>
        public QuotaRepositoryDockForm()
        {
            this.InitializeComponent();

            DateTimePicker dateTimePicker = new DateTimePicker();
            ToolStripControlHost controlHost = new ToolStripControlHost(dateTimePicker);

            this.QuotaRepositoryToolStrip.Items.Add(controlHost);
        }
        #endregion
    }
}
