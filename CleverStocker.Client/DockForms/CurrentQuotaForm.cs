using System;
using System.ComponentModel;
using System.Threading.Tasks;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 实时行情
    /// </summary>
    public partial class CurrentQuotaForm : SingleToolDockForm, IMQPubsubable
    {
        #region 服务

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 股票爬虫服务
        /// </summary>
        protected IStockSpiderService StockSpiderService { get; set; }

        /// <summary>
        /// Gets or sets 行情服务
        /// </summary>
        protected IQuotaService QuotaService { get; set; }
        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets 源名称
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SourceName { get; set; } = typeof(CurrentQuotaForm).Name;

        /// <summary>
        /// Gets or sets mQ 订阅者
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SubscriberHandler Subscriber { get; set; }

        private Stock currentStock;

        /// <summary>
        /// Gets or sets 当前股票
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Stock CurrentStock
        {
            get => this.currentStock;
            protected set
            {
                this.currentStock = value;

                this.MainStockQuotaControl.Stock = value;
                this.MainFiveGearControl.Stock = value;

                if (value == null)
                {
                    LogHelper<CurrentQuotaForm>.Debug("当前行情窗口收到了空股票，关闭自动刷新行情功能 ...");

                    this.Invoke(new Action(() =>
                    {
                        this.CurrentQuotaToolStrip.Enabled = false;
                        this.AutoRefresh = false;
                    }));
                }
                else
                {
                    LogHelper<CurrentQuotaForm>.Debug("当前行情窗口收到了一支股票，开启自动刷新行情功能 ...");

                    this.Invoke(new Action(() =>
                    {
                        /* 选中非空股票自动开启自动刷新行情功能
                        this.AutoRefresh = true;
                         */
                        this.CurrentQuotaToolStrip.Enabled = true;
                    }));
                }
            }
        }

        private Quota currentQuota;

        /// <summary>
        /// Gets or sets 当前行情
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Quota CurrentQuota
        {
            get => this.currentQuota;
            protected set
            {
                this.currentQuota = value;

                this.MainStockQuotaControl.AttachEntity = value;
                this.MainFiveGearControl.AttachEntity = value;
            }
        }

        /// <summary>
        /// 正在设置属性
        /// </summary>
        private bool isPropertySetting = false;

        /// <summary>
        /// Gets or sets a value indicating whether 自动刷新
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutoRefresh
        {
            get => this.AutoRefreshToolButton.Checked;
            set
            {
                // 防止循环调用
                if (this.isPropertySetting)
                {
                    return;
                }

                this.isPropertySetting = true;
                this.AutoRefreshToolButton.Checked = value;
                this.isPropertySetting = false;

                if (value)
                {
                    LogHelper<CurrentQuotaForm>.Debug("开启自动刷新行情功能 ...");

                    this.AutoRefreshToolButton.Image = AppResource.Service;

                    // Timer 重启后会自动重置等待时间，以重新等待
                    this.AutoRefreshTimer.Start();
                }
                else
                {
                    LogHelper<CurrentQuotaForm>.Debug("关闭自动刷新行情功能 ...");

                    this.AutoRefreshToolButton.Image = AppResource.ServiceFabric;
                    this.AutoRefreshTimer.Stop();
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentQuotaForm"/> class.
        /// </summary>
        public CurrentQuotaForm()
            : base()
        {
            this.InitializeComponent();

            this.Icon = AppResource.CurrentQuotaIcon;
            this.HideOnClose = true;
            this.CloseButton = false;
            this.CloseButtonVisible = false;
        }

        private void CurrentQuotaForm_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.QuotaService = DIContainerHelper.Resolve<IQuotaService>();
            this.StockService = DIContainerHelper.Resolve<IStockService>();
            this.StockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();

            this.Subscriber = MQHelper.Subscribe(
                this.SourceName,
                new[] { MQTopics.TopicStockCurrentChange },
                this.MQSubscriberReceive);

            this.AutoRefresh = false;
        }
        #endregion

        #region 功能

        /// <summary>
        /// MQ 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        public void MQSubscriberReceive(string source, string topic, string message)
        {
            LogHelper<CurrentQuotaForm>.Debug($"收到来自 {source} 的消息：{topic} - {message}");

            var (code, market, _) = message.GetMarketCode();

            if (string.Equals(this.currentStock?.Code, code, StringComparison.OrdinalIgnoreCase) &&
                this.currentStock?.Market == market)
            {
                return;
            }
            else
            {
                var stock = this.StockService.Find(code, market);
                this.CurrentStock = stock;
                this.CurrentQuota = this.QuotaService?.GetLastQuota(code, market);
            }
        }

        /// <summary>
        /// 更新行情
        /// </summary>
        /// <returns></returns>
        public async Task RefreshQuota()
        {
            try
            {
                LogHelper<CurrentQuotaForm>.Debug($"刷新股票 {this.currentStock.GetFullCode()} 行情 ...");

                var (_, quota) = await this.StockSpiderService.GetStockQuotaAsync(this.currentStock.Code, this.currentStock.Market);

                this.CurrentQuota = quota;

                if (quota != null)
                {
                    this.QuotaService.AddOrUpdate(quota);
                }
            }
            catch (Exception ex)
            {
                LogHelper<CurrentQuotaForm>.ErrorException(ex, $"刷新行情失败：");
            }
        }
        #endregion

        #region 控件

        private void AutoRefreshToolButton_CheckedChanged(object sender, EventArgs e)
        {
            this.AutoRefresh = this.AutoRefreshToolButton.Checked;
        }

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            _ = this.RefreshQuota();
        }

        private void AutoRefreshTimer_Tick(object sender, EventArgs e)
        {
            _ = this.RefreshQuota();
        }

        private void QuotaRepositoryToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var form = DIContainerHelper.Resolve<QuotaRepositoryDocumentForm>();
            if (form == null)
            {
                return;
            }

            form.Stock = this.currentStock;
            form.Show(this.DockPanel);
        }

        private void ChartToolButton_Click(object sender, EventArgs e)
        {
            if (this.currentStock == null)
            {
                return;
            }

            var form = DIContainerHelper.Resolve<ChartDocumentForm>();
            if (form == null)
            {
                return;
            }

            form.Stock = this.currentStock;
            form.Show(this.DockPanel);
        }
        #endregion

        #region 主题

        /// <summary>
        /// 应用主题
        /// </summary>
        public override void ApplyTheme()
        {
            base.ApplyTheme();

            ThemeHelper.CurrentThemeComponent.ApplyTo(this.CurrentQuotaToolStrip);

            this.MainStockQuotaControl.LabelForecolor = ThemeHelper.GetTitleForecolor();
            this.MainStockQuotaControl.ValueForecolor = ThemeHelper.GetContentForecolor();

            this.MainFiveGearControl.LabelForecolor = this.MainStockQuotaControl.LabelForecolor;
            this.MainFiveGearControl.ValueForecolor = this.MainStockQuotaControl.ValueForecolor;
        }
        #endregion

        #region 释放

        private void CurrentQuotaForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.AutoRefreshTimer.Stop();
            this.Subscriber?.Dispose();
        }
        #endregion
    }
}
