using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Model.Comparers;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client.DockForms
{
    // TODO: 参照自选股票窗口实现（交互设计细节、代码编写细节），并将细节步骤整理为文档

    /// <summary>
    /// 自选股票窗口
    /// </summary>
    public partial class SelfSelectStockForm : SingleToolDockForm, IMQPubsubable
    {
        #region 服务

        /// <summary>
        /// 股票比较器
        /// </summary>
        private readonly StockComparer stockComparer = new StockComparer();

        /// <summary>
        /// Gets or sets mQ 订阅者
        /// </summary>
        public SubscriberHandler Subscriber { get; set; }

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }
        #endregion

        #region 属性

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

                    MQHelper.Publish(this.SourceName, MQTopics.TopicStockCurrentChange, value.GetFullCode());
                }
            }
        }
        #endregion

        #region 初始化

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
            if (this.DesignMode)
            {
                return;
            }

            this.StockService = DIContainerHelper.Resolve<IStockService>();

            this.Subscriber = MQHelper.Subscribe(
                this.SourceName,
                new[] { MQTopics.TopicStockSelfSelect },
                this.MQSubscriberReceive);
        }

        private void SelfSelectStockForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.RefreshDataSource();
        }
        #endregion

        #region 外观

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

            this.SearchToolTextBox.BackColor = this.BackColor;
            this.SearchToolTextBox.ForeColor = this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.ForeColor;
        }
        #endregion

        #region MQ消息

        /// <summary>
        /// MQ 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        public void MQSubscriberReceive(string source, string topic, string message)
        {
            LogHelper<SelfSelectStockForm>.Debug($"收到来自 {source} 的消息：{topic} - {message}");

            var (code, market, name) = message.GetMarketCode();
            if (string.IsNullOrWhiteSpace(code) ||
                market == Markets.Unknown)
            {
                LogHelper<SelfSelectStockForm>.Warn($"无法处理 [代码={code},市场={market.ToString()},名称={name}] 的股票。");
                return;
            }

            Stock stock = this.StockService.Find(code, market);
            if (stock == null)
            {
                stock = new Stock(code, market, name);
            }

            if (string.Equals(topic, MQTopics.TopicStockSelfSelectAdd, StringComparison.OrdinalIgnoreCase))
            {
                this.Invoke(new Action(() =>
                {
                    this.AddSelfSelectStock(stock);
                }));
            }
            else if (string.Equals(topic, MQTopics.TopicStockSelfSelectRemove, StringComparison.OrdinalIgnoreCase))
            {
                this.Invoke(new Action(() =>
                {
                    this.RemoveSelfSelectStock(stock);
                }));
            }
        }
        #endregion

        #region 控件

        private void SelfSelectStockGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.CurrentStock = this.SelfSelectStockGridView.CurrentRow?.DataBoundItem as Stock;
        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void RefreshMenuItem_Click(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void RemoveToolButton_Click(object sender, EventArgs e)
        {
            this.RemoveSelfSelectStock(this.currentStock);
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            this.RemoveSelfSelectStock(this.currentStock);
        }

        private void SearchToolTextBox_TextChanged(object sender, EventArgs e)
        {
            string keyWord = this.SearchToolTextBox.Text;

            if (string.IsNullOrWhiteSpace(keyWord))
            {
                this.RefreshDataSource();
            }
            else
            {
                this.SelfSelectStockBindingSource.DataSource = this.StockService.QueryStock(true, keyWord);
            }
        }

        private void AddToolButton_Click(object sender, EventArgs e)
        {
            this.ShowSearchStockDockForm();
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowSearchStockDockForm();
        }
        #endregion

        #region 数据

        /// <summary>
        /// 刷新数据源
        /// </summary>
        private void RefreshDataSource()
        {
            this.SelfSelectStockBindingSource.DataSource = this.StockService.QueryStock(true);
        }

        /// <summary>
        /// 移除自选股票
        /// </summary>
        /// <param name="stock"></param>
        private void RemoveSelfSelectStock(Stock stock)
        {
            if (stock == null)
            {
                return;
            }

            LogHelper<SelfSelectStockForm>.Debug($"移除自选股票：{this.currentStock.Market} - {this.currentStock.Code}");
            this.StockService.RemoveSelfSelectStock(stock);

            if (this.CheckDataSourceContains(stock))
            {
                this.SelfSelectStockBindingSource.Remove(stock);
            }
        }

        /// <summary>
        /// 添加自选股票
        /// </summary>
        /// <param name="stock"></param>
        private void AddSelfSelectStock(Stock stock)
        {
            if (stock == null)
            {
                return;
            }

            LogHelper<SelfSelectStockForm>.Debug($"添加自选股票：{stock.Market} - {stock.Code}");
            this.StockService.AddSelfSelectStock(stock);

            if (!this.CheckDataSourceContains(stock))
            {
                this.SelfSelectStockBindingSource.Add(stock);
            }
        }

        /// <summary>
        /// 检查数据源是否包含指定股票
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private bool CheckDataSourceContains(Stock stock)
            => (this.SelfSelectStockBindingSource.DataSource as IEnumerable<Stock>)
                .Contains(stock, this.stockComparer);
        #endregion

        #region 功能

        /// <summary>
        /// 显示搜索股票窗口
        /// </summary>
        private void ShowSearchStockDockForm()
        {
            SearchStockDockForm dockForm = DIContainerHelper.Resolve<SearchStockDockForm>();
            if (dockForm == null)
            {
                return;
            }

            dockForm.Show(this.Pane, this);
        }
        #endregion

        #region 释放

        private void SelfSelectStockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Subscriber?.Dispose();
        }
        #endregion
    }
}
