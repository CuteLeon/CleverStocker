using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CleverStocker.Model;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 行情仓库停靠窗口
    /// </summary>
    public partial class QuotaRepositoryDockForm : DocumentDockForm
    {
        #region 服务

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 行情服务
        /// </summary>
        protected IQuotaService QuotaService { get; set; }
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
                    this.Text = "行情仓库-[空股票]";
                    this.StockInfoToolLabel.Text = "[空股票]";

                    this.QuotaRepositoryToolStrip.Enabled = false;
                }
                else
                {
                    this.Text = $"行情仓库-{value.Name}";
                    this.StockInfoToolLabel.Text = value.Name;

                    this.QuotaRepositoryToolStrip.Enabled = true;
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotaRepositoryDockForm"/> class.
        /// </summary>
        public QuotaRepositoryDockForm()
            : base()
        {
            this.InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            this.QuotaService = DIContainerHelper.Resolve<IQuotaService>();
            this.StockService = DIContainerHelper.Resolve<IStockService>();
        }

        private void QuotaRepositoryDockForm_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            ToolStripControlHost startDatePickerHost = new ToolStripControlHost(this.QuotaStartDatePicker);
            ToolStripControlHost endDatePickerHost = new ToolStripControlHost(this.QuotaEndDatePicker);
            int insertIndex = this.QuotaRepositoryToolStrip.Items.IndexOf(this.StartTimeToolLabel) + 1;
            this.QuotaRepositoryToolStrip.Items.Insert(insertIndex, startDatePickerHost);
            insertIndex = this.QuotaRepositoryToolStrip.Items.IndexOf(this.EndTimeToolLabel) + 1;
            this.QuotaRepositoryToolStrip.Items.Insert(insertIndex, endDatePickerHost);

            this.QuotaStartDatePicker.Value = DateTime.Now.AddDays(-7);
            this.QuotaEndDatePicker.Value = DateTime.Now;
        }

        private void QuotaRepositoryDockForm_Shown(object sender, EventArgs e)
        {
            this.QueryQuotas();
        }
        #endregion

        #region 主题

        /// <summary>
        /// 应用主题
        /// </summary>
        public override void ApplyTheme()
        {
            base.ApplyTheme();

            // 配置数据单元格样式：DataGridView.RowTemplate.DefaultCellStyle
            this.QuotaRepositoryGridView.BackgroundColor = this.BackColor;
            this.QuotaRepositoryGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.ForeColor = ThemeHelper.GetContentForecolor();
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = ThemeHelper.GetContentHighLightBackcolor();
            this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = ThemeHelper.GetContentHighLightForecolor();

            /* 配置标题单元格样式：DataGridView.ColumnHeadersDefaultCellStyle
             * < DataGridView 需要关闭此设置才可以应用样式 >
             */
            this.QuotaRepositoryGridView.EnableHeadersVisualStyles = false;
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeHelper.GetTitleBackcolor();
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.ForeColor = ThemeHelper.GetTitleForecolor();
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.BackColor;
            this.QuotaRepositoryGridView.ColumnHeadersDefaultCellStyle.Font = this.QuotaRepositoryGridView.RowTemplate.DefaultCellStyle.Font;
        }
        #endregion

        #region 控件

        private void QueryToolButton_Click(object sender, EventArgs e)
        {
            this.QueryQuotas();
        }
        #endregion

        #region 功能

        private void QueryQuotas()
        {
            this.QuotaRepositoryBindingSource.DataSource = this.QuotaService.QueryQuotas(
                this.stock.Code,
                this.stock.Market,
                this.QuotaStartDatePicker.Checked ? (DateTime?)this.QuotaStartDatePicker.Value.Date : null,
                this.QuotaEndDatePicker.Checked ? (DateTime?)this.QuotaEndDatePicker.Value.Date.AddHours(24).AddSeconds(-1) : null);
        }
        #endregion
    }
}
