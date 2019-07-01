using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Model.Comparers;
using CleverStocker.Services;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

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

        private Stock currentStock;

        /// <summary>
        /// Gets or sets 当前选中的股票
        /// </summary>
        /// <remarks>应注意减少频繁发送重复的消息</remarks>
        public Stock CurrentStock
        {
            get => this.currentStock;
            protected set
            {
                if (this.currentStock == value)
                {
                    return;
                }

                this.currentStock = value;

                if (value == null)
                {
                    this.RemoveMenuItem.Enabled = false;
                    this.RemoveToolButton.Enabled = false;

                    MQHelper.Publish(this.SourceName, MQTopics.TopicStockCurrentChange, string.Empty);
                }
                else
                {
                    this.RemoveMenuItem.Enabled = true;
                    this.RemoveToolButton.Enabled = true;

                    MQHelper.Publish(this.SourceName, MQTopics.TopicStockCurrentChange, $"{value.Market.ToString()}{MQHelper.Separator[0]}{value.Code}");
                }
            }
        }

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

            this.Subscriber = MQHelper.Subscribe(
                this.SourceName,
                new[] { MQTopics.TopicStockSelfSelect },
                this.MQSubscriberReceive);

            this.RefreshDataSource();
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
            this.CurrentStock = this.SelfSelectStockGridView.CurrentRow?.DataBoundItem as Stock;
        }

        private void SelfSelectStockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Subscriber?.Dispose();
        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshDataSource()
        {
            this.SelfSelectStockBindingSource.DataSource = this.StockService.GetSelfSelectStocks();
        }

        private void RemoveToolButton_Click(object sender, EventArgs e)
        {
            this.RemoveSelfSelectStock();
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            this.RemoveSelfSelectStock();
        }

        /// <summary>
        /// 移除自选股票
        /// </summary>
        private void RemoveSelfSelectStock()
        {
            if (this.currentStock == null)
            {
                return;
            }

            LogHelper<SelfSelectStockForm>.Debug($"移除自选股票：{this.currentStock.Market} - {this.currentStock.Code}");

            this.StockService.RemoveSelfSelectStock(this.currentStock);
            this.SelfSelectStockBindingSource.Remove(this.currentStock);
        }

        private void AddToolButton_Click(object sender, EventArgs e)
        {
            this.AddSelfSelectStock();
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            this.AddSelfSelectStock();
        }

        /// <summary>
        /// 添加自选股票
        /// </summary>
        private void AddSelfSelectStock()
        {
            // TODO: 添加自选股票
            Stock stock = new Stock("000002", Markets.ShangHai) { Name = "测试股票" };

            // 判断数据源是否已经存在此自选股票
            if ((this.SelfSelectStockBindingSource.DataSource as IEnumerable<Stock>)
                .Contains(stock, new StockComparer()))
            {
                return;
            }

            LogHelper<SelfSelectStockForm>.Debug($"添加自选股票：{stock.Market} - {stock.Code}");

            this.StockService.AddSelfSelectStock(stock);
            this.SelfSelectStockBindingSource.Add(stock);
        }
    }
}
