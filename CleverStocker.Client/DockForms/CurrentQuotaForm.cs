using System;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Utils;
using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 实时行情
    /// </summary>
    public partial class CurrentQuotaForm : SingleToolDockForm, IMQPubsubable
    {
        /// <summary>
        /// Gets or sets mQ 订阅者
        /// </summary>
        public SubscriberHandler Subscriber { get; set; }

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        public string SourceName { get; set; } = typeof(CurrentQuotaForm).Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentQuotaForm"/> class.
        /// </summary>
        public CurrentQuotaForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.CurrentQuotaIcon;
            this.HideOnClose = true;
            this.CloseButton = false;
            this.CloseButtonVisible = false;
        }

        /// <summary>
        /// Gets or sets 默认首次启动停靠状态
        /// </summary>
        public override DockState DefaultLaunchDockState { get; set; } = DockState.DockRight;

        private void CurrentQuotaForm_Load(object sender, System.EventArgs e)
        {
            this.Subscriber = MQHelper.Subscribe(
                this.SourceName,
                new[] { MQTopics.TopicStockCurrentChange },
                this.MQSubscriberReceive);
        }

        /// <summary>
        /// MQ 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        public void MQSubscriberReceive(string source, string topic, string message)
        {
            LogHelper<CurrentQuotaForm>.Debug($"收到来自 {source} 的消息：{topic} - {message}");

            this.Invoke(new Action(() =>
            {
                this.MainLabel.Text = $"行情 of\n{message}";
            }));
        }

        private void CurrentQuotaForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Subscriber?.Dispose();
        }
    }
}
