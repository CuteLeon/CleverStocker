using System;
using CleverStocker.Common;
using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 自选股票窗口
    /// </summary>
    public partial class SelfSelectStockForm : ToolDockForm
    {
        /// <summary>
        /// Gets or sets mQ 订阅者
        /// </summary>
        protected SubscriberHandler Subscriber { get; set; }

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfSelectStockForm"/> class.
        /// </summary>
        public SelfSelectStockForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.SelfSelectIcon;
            this.HideOnClose = true;
        }

        private void SelfSelectStockForm_Load(object sender, EventArgs e)
        {
            this.StockService = DIContainerHelper.Resolve<IStockService>();

            this.stockBindingSource.DataSource = this.StockService.GetSelfSelectStocks();
            this.Subscriber = MQHelper.Subscribe(
                "SelfSelectStockForm",
                new[] { MQTopics.TopicStockSelfSelect },
                this.Subscriber_Receive);
        }

        /// <summary>
        /// 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        private void Subscriber_Receive(string source, string topic, string message)
        {
            LogHelper<SelfSelectStockForm>.Debug($"收到 {source} 发来的消息：{topic} - {message}");

            this.Invoke(new Action(() =>
            {
                this.Text = $"消息：{message}";
            }));
        }
    }
}
