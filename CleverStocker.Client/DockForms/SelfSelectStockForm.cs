using System;
using System.Drawing;
using System.Windows.Forms;
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

            // 配置数据单元格样式：DataGridView.RowTemplate.DefaultCellStyle
            this.SelfSelectStockGridView.BackgroundColor = this.BackColor;
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.ForeColor = ThemeHelper.GetContentForecolor();
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = ThemeHelper.GetContentHighLightBackcolor();
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = ThemeHelper.GetContentHighLightForecolor();

            /* 配置标题单元格样式：DataGridView.ColumnHeadersDefaultCellStyle
             * < DataGridView 需要关闭此设置才可以应用样式 >
             */
            this.SelfSelectStockGridView.EnableHeadersVisualStyles = false;
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeHelper.GetTitleBackcolor();
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.ForeColor = ThemeHelper.GetTitleForecolor();
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.BackColor;
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle.Font = new Font(this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Font, FontStyle.Regular);
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
