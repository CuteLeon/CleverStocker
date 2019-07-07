using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using CleverStocker.Model;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 图表文档窗口
    /// </summary>
    public partial class ChartDocumentForm : DocumentDockForm
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
        #endregion

        #region 属性

        /// <summary>
        /// Gets or sets 布局持久化数据
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string PersistValue
        {
            get => this.stock?.GetFullCode();
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                var (code, market, _) = value.GetMarketCode();
                this.Stock = this.StockService.Find(code, market);
            }
        }

        private Stock stock;

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Stock Stock
        {
            get => this.stock;
            set
            {
                this.stock = value;

                if (value == null)
                {
                    this.Text = "图表-[空股票]";
                    this.StockInfoToolLabel.Text = "[空股票]";
                    this.ChartRepositoryToolStrip.Enabled = false;
                }
                else
                {
                    this.Text = $"图表-{value.Name}";
                    this.StockInfoToolLabel.Text = value.Name;
                    this.ChartRepositoryToolStrip.Enabled = true;
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartDocumentForm"/> class.
        /// </summary>
        public ChartDocumentForm()
            : base()
        {
            this.InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            this.StockService = DIContainerHelper.Resolve<IStockService>();
            this.StockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();

            this.ChartTypeToolComboBox.Items.AddRange(Enum.GetNames(typeof(Charts)));
            this.ChartTypeToolComboBox.SelectedIndex = 0;
        }

        private void ChartDocumentForm_Shown(object sender, EventArgs e)
        {
            _ = this.RefreshChart();
        }
        #endregion

        #region 功能

        /// <summary>
        /// 显示图表
        /// </summary>
        private async Task RefreshChart()
        {
            Image chartImage = await this.StockSpiderService.GetChartAsync(
                this.stock.Code,
                this.stock.Market,
                Enum.TryParse(this.ChartTypeToolComboBox.SelectedItem.ToString(), out Charts chart) ? chart : Charts.Minute);

            this.ChartPictureBox.BackgroundImage = chartImage;
        }
        #endregion

        #region 控件

        private void RefreshToolButton_Click(object sender, EventArgs e)
        {
            _ = this.RefreshChart();
        }
        #endregion
    }
}
