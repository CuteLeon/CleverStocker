using System;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 自选股票窗口
    /// </summary>
    public partial class SelfSelectStockForm : SingleToolDockForm, IMQPubsubable
    {
        /// <summary>
        /// Gets or sets mQ 订阅者
        /// </summary>
        public SubscriberHandler Subscriber { get; set; }

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        public string SourceName { get; set; } = typeof(SelfSelectStockForm).Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelfSelectStockForm"/> class.
        /// </summary>
        public SelfSelectStockForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.SelfSelectIcon;

            this.TabPageContextMenuStrip = this.SelfSelectGridViewMenuStrip;
            this.SelfSelectStockGridView.ContextMenuStrip = this.SelfSelectGridViewMenuStrip;
        }

        private void SelfSelectStockForm_Load(object sender, EventArgs e)
        {
            this.StockService = DIContainerHelper.Resolve<IStockService>();

            this.SelfSelectStockBindingSource.DataSource = this.StockService.GetSelfSelectStocks();

            this.Subscriber = MQHelper.Subscribe(
                this.SourceName,
                new[] { MQTopics.TopicStockSelfSelect },
                this.MQSubscriberReceive);
        }

        /// <summary>
        /// 应用主题
        /// </summary>
        public override void ApplyTheme()
        {
            base.ApplyTheme();
            ThemeHelper.CurrentThemeComponent.ApplyTo(this.SelfSelectGridViewMenuStrip);

            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.BackColor = this.BackColor;
            this.SelfSelectStockGridView.BackgroundColor = this.BackColor;
        }

        /// <summary>
        /// MQ 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        public void MQSubscriberReceive(string source, string topic, string message)
        {
            LogHelper<SelfSelectStockForm>.Debug($"收到来自 {source} 的消息：{topic} - {message}");
        }

        private void SelfSelectStockGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!(this.SelfSelectStockGridView.CurrentRow.DataBoundItem is Stock stock))
            {
                return;
            }

            // 发布消息：当前股票变化
            MQHelper.Publish(this.SourceName, MQTopics.TopicStockCurrentChange, $"{stock.Market.ToString()}{MQHelper.Separator[0]}{stock.Code}");
        }

        private void SelfSelectStockForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Subscriber?.Dispose();
        }
    }
}
