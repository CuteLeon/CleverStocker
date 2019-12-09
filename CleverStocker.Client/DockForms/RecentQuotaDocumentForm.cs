using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CleverStocker.ML;
using CleverStocker.ML.NextOpenPrice;
using CleverStocker.Model;
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client.DockForms
{
    /// <summary>
    /// 最近行情文档窗口
    /// </summary>
    public partial class RecentQuotaDocumentForm : DocumentDockForm
    {
        #region 服务

        /// <summary>
        /// Gets or sets 股票服务
        /// </summary>
        protected IStockService StockService { get; set; }

        /// <summary>
        /// Gets or sets 最近行情服务
        /// </summary>
        protected IRecentQuotaService RecentQuotaService { get; set; }

        /// <summary>
        /// Gets or sets 爬虫服务
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
                    this.Text = "最近行情-[空股票]";
                    this.StockInfoToolLabel.Text = "[空股票]";

                    this.RecentQuotaToolStrip.Enabled = false;
                }
                else
                {
                    this.Text = $"最近行情-{value.Name}";
                    this.StockInfoToolLabel.Text = value.Name;

                    this.RecentQuotaToolStrip.Enabled = true;
                }
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuotaDocumentForm"/> class.
        /// </summary>
        public RecentQuotaDocumentForm()
        {
            this.InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            this.TimeScaleToolComboBox.Items.AddRange(Enum.GetNames(typeof(TimeScales)));
            this.StockService = DIContainerHelper.Resolve<IStockService>();
            this.RecentQuotaService = DIContainerHelper.Resolve<IRecentQuotaService>();
            this.StockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
        }

        private void RecentQuotaDocumentForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            ToolStripControlHost quotaLengthNumericHost = new ToolStripControlHost(this.QuotaLengthNumeric);
            int insertIndex = this.RecentQuotaToolStrip.Items.IndexOf(this.QuotaLengthToolLabel) + 1;
            this.RecentQuotaToolStrip.Items.Insert(insertIndex, quotaLengthNumericHost);

            this.TimeScaleToolComboBox.SelectedIndex = 0;
            this.QuotaLengthNumeric.Value = 20;
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
            this.RecentQuotaGridView.BackgroundColor = this.BackColor;
            this.RecentQuotaGridView.RowHeadersDefaultCellStyle.BackColor = this.BackColor;
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.BackColor = this.BackColor;
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.ForeColor = ThemeHelper.GetContentForecolor();
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = ThemeHelper.GetContentHighLightBackcolor();
            this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = ThemeHelper.GetContentHighLightForecolor();

            /* 配置标题单元格样式：DataGridView.ColumnHeadersDefaultCellStyle
             * < DataGridView 需要关闭此设置才可以应用样式 >
             */
            this.RecentQuotaGridView.EnableHeadersVisualStyles = false;
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeHelper.GetTitleBackcolor();
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.ForeColor = ThemeHelper.GetTitleForecolor();
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.BackColor;
            this.RecentQuotaGridView.ColumnHeadersDefaultCellStyle.Font = this.RecentQuotaGridView.RowTemplate.DefaultCellStyle.Font;
        }
        #endregion

        #region 控件

        private void QueryToolButton_Click(object sender, EventArgs e)
        {
            _ = this.QueryRecentQuotas();
        }

        private void ExportToolButton_Click(object sender, EventArgs e)
        {
            if (this.stock == null)
            {
                return;
            }

            if (this.RecentQuotaGridView.Rows.Count == 0)
            {
                return;
            }

            using (var dialog = new SaveFileDialog()
            {
                DefaultExt = ".txt",
                FileName = $"{this.Stock.Name}-{this.Stock.Code}_行情",
                Filter = "文本文件|*.txt|所有文件|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "请选择导出文件路径：",
            })
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fileName = dialog.FileName;
                using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        string line = "代码\t市场\t名称\t开盘价(元)\t收盘价(元)\t最高价(元)\t最低价(元)\t交易量\t更新时间\t下次开盘价(元)";
                        streamWriter.WriteLine(line);

                        var quotas = (this.RecentQuotaBindingSource.DataSource as List<RecentQuota>)
                            .OrderByDescending(quota => quota.UpdateTime)
                            .ToList();

                        var firstQuota = quotas.First();
                        line = $"{firstQuota.Code}\t{firstQuota.Market}\t{firstQuota.Name}\t{firstQuota.OpenningPrice}\t{firstQuota.ClosingPrice}\t{firstQuota.HighestPrice}\t{firstQuota.LowestPrice}\t{firstQuota.Volume}\t{firstQuota.UpdateTime}\t{string.Empty}";
                        streamWriter.WriteLine(line);

                        quotas.Skip(1)
                            .Select((quota, index) =>
                            {
                                line = $"{quota.Code}\t{quota.Market}\t{quota.Name}\t{quota.OpenningPrice}\t{quota.ClosingPrice}\t{quota.HighestPrice}\t{quota.LowestPrice}\t{quota.Volume}\t{quota.UpdateTime}\t{quotas[index].OpenningPrice}";
                                streamWriter.WriteLine(line);
                                return line;
                            })
                            .Count();
                    }
                }
            }

            MessageBox.Show(this, $"{this.Stock.Name}-{this.Stock.Code} 行情导出成功！", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MLTransformButton_Click(object sender, EventArgs e)
        {
            if (this.stock == null)
            {
                return;
            }

            if (this.RecentQuotaGridView.Rows.Count == 0)
            {
                return;
            }

            // TODO: 实现 ML 业务功能；
            var convertor = DIContainerHelper.Resolve<INOPInputConverter>();
            var transformer = DIContainerHelper.Resolve<INOPStockTransformer>();
            var prediction = DIContainerHelper.Resolve<INOPStockPrediction>();

            const string modelPath = @"D:\ML\Model.zip";
            var quotas = this.RecentQuotaBindingSource.DataSource as List<RecentQuota>;
            var inputs = convertor.ConvertInputs(quotas);
            transformer.InitializeEstimator();
            transformer.Fit(inputs);
            transformer.SaveModel(modelPath);

            var quota = quotas.First();
            var input = convertor.ConvertInput(quota);
            prediction.LoadModelToPredictionEngine(modelPath);
            var output = prediction.Predict(input);
            MessageBox.Show($"预测结果：{output.ToString()}");
        }
        #endregion

        #region 功能

        /// <summary>
        /// 查询最近行情
        /// </summary>
        /// <returns></returns>
        public async Task QueryRecentQuotas()
        {
            if (this.stock == null)
            {
                return;
            }

            var recentQuotas = await this.StockSpiderService.GetRecentQuotasAsync(
                this.stock.Code,
                this.stock.Market,
                Enum.TryParse(this.TimeScaleToolComboBox.SelectedItem.ToString(), out TimeScales scale) ? scale : TimeScales.Minutes_5,
                Convert.ToInt32(this.QuotaLengthNumeric.Value));
            recentQuotas.ForEach(quota => quota.Name = this.stock.Name);

            this.RecentQuotaBindingSource.DataSource = recentQuotas;

            this.RecentQuotaService.AddOrUpdate(recentQuotas.ToArray());
        }
        #endregion
    }
}
