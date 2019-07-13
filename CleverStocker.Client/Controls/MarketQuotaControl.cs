using System.Drawing;
using System.Windows.Forms;
using CleverStocker.Model;
using CleverStocker.Utils;

namespace CleverStocker.Client.Controls
{
    /// <summary>
    /// 大盘指数控件
    /// </summary>
    public partial class MarketQuotaControl : StockAttachControlBaseGeneric<MarketQuota>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuotaControl"/> class.
        /// </summary>
        public MarketQuotaControl()
        {
            this.InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            this.CurrentPriceValueLabel.ImageList = new ImageList();
            this.CurrentPriceValueLabel.ImageList.Images.Add(AppResource.UpArrow);
            this.CurrentPriceValueLabel.ImageList.Images.Add(AppResource.DownArrow);
        }

        /// <summary>
        /// 设置标签前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetLabelForecolor(Color color)
        {
            this.CountLabel.ForeColor = color;
            this.AmountLabel.ForeColor = color;
            this.UpdateTimeLabel.ForeColor = color;
            this.CodeValueLabel.ForeColor = color;
            this.MarketValueLabel.ForeColor = color;
            this.StockNameValueLabel.ForeColor = color;
            this.UpdateTimeValueLabel.ForeColor = color;
        }

        /// <summary>
        /// 设置值前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetValueForecolor(Color color)
        {
            this.CurrentPriceValueLabel.ForeColor = color;
            this.FluctuatingRangeValueLabel.ForeColor = color;
            this.FluctuatingRateValueLabel.ForeColor = color;
            this.CountValueLabel.ForeColor = color;
            this.AmountValueLabel.ForeColor = color;
        }

        /// <summary>
        /// 应用股票数据到界面
        /// </summary>
        /// <param name="stock"></param>
        public override void StockToFace(Stock stock)
        {
            if (stock == null)
            {
                this.CodeValueLabel.Text = "-";
                this.MarketValueLabel.Text = "-";
                this.StockNameValueLabel.Text = "-";
            }
            else
            {
                this.CodeValueLabel.Text = stock.Code;
                this.MarketValueLabel.Text = stock.Market.ToString();
                this.StockNameValueLabel.Text = stock.Name;
            }
        }

        /// <summary>
        /// 应用行情数据到界面
        /// </summary>
        /// <param name="quota"></param>
        public override void AttachEntityToFace(MarketQuota quota)
        {
            if (quota == null)
            {
                this.CurrentPriceValueLabel.ImageIndex = -1;
                this.CurrentPriceValueLabel.ForeColor = this.ValueForecolor;
                this.FluctuatingRangeValueLabel.ForeColor = this.ValueForecolor;
                this.FluctuatingRateValueLabel.ForeColor = this.ValueForecolor;

                this.CurrentPriceValueLabel.Text = "-";
                this.FluctuatingRangeValueLabel.Text = "-";
                this.FluctuatingRateValueLabel.Text = "-";
                this.CountValueLabel.Text = "-";
                this.AmountValueLabel.Text = "-";
                this.UpdateTimeValueLabel.Text = "-";
            }
            else
            {
                this.CurrentPriceValueLabel.ImageIndex =
                    this.stockComparer.Equals(quota, this.lastAttachEntity) ?
                        quota.CurrentPrice > this.lastAttachEntity.CurrentPrice ?
                            0 : // 价格上涨显示向上箭头
                            quota.CurrentPrice < this.lastAttachEntity.CurrentPrice ?
                                1 : // 价格下跌，显示向下箭头
                                -1 : // 价格无变动，不显示箭头
                            -1; // 不是同一股票，不显示箭头

                Color quotaForecolor = ThemeHelper.GetQuotaForecolor(quota.FluctuatingRange);
                this.CurrentPriceValueLabel.ForeColor = quotaForecolor;
                this.FluctuatingRangeValueLabel.ForeColor = quotaForecolor;
                this.FluctuatingRateValueLabel.ForeColor = quotaForecolor;

                this.CurrentPriceValueLabel.Text = quota.CurrentPrice.ToString("N4");
                this.FluctuatingRangeValueLabel.Text = quota.FluctuatingRange.ToString("N4");
                this.FluctuatingRateValueLabel.Text = $"{quota.FluctuatingRate.ToString("N4")} %";
                this.CountValueLabel.Text = quota.Count.ToString("N0");
                this.AmountValueLabel.Text = quota.Amount.ToString("N0");
                this.UpdateTimeValueLabel.Text = quota.UpdateTime.ToString("HH:mm:ss");
            }
        }
    }
}
