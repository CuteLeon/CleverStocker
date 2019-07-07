using System.Drawing;
using CleverStocker.Model;

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
        }

        /// <summary>
        /// 设置标签前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetLabelForecolor(Color color)
        {
            this.CodeLabel.ForeColor = color;
            this.MarketLabel.ForeColor = color;
            this.StockNameLabel.ForeColor = color;
            this.CurrentPriceLabel.ForeColor = color;
            this.FluctuatingRangeLabel.ForeColor = color;
            this.FluctuatingRateLabel.ForeColor = color;
            this.CountLabel.ForeColor = color;
            this.AmountLabel.ForeColor = color;
            this.UpdateTimeLabel.ForeColor = color;
        }

        /// <summary>
        /// 设置值前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetValueForecolor(Color color)
        {
            this.CodeValueLabel.ForeColor = color;
            this.MarketValueLabel.ForeColor = color;
            this.StockNameValueLabel.ForeColor = color;
            this.CurrentPriceValueLabel.ForeColor = color;
            this.FluctuatingRangeValueLabel.ForeColor = color;
            this.FluctuatingRateValueLabel.ForeColor = color;
            this.CountValueLabel.ForeColor = color;
            this.AmountValueLabel.ForeColor = color;
            this.UpdateTimeValueLabel.ForeColor = color;
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
                this.CurrentPriceValueLabel.Text = "-";
                this.FluctuatingRangeValueLabel.Text = "-";
                this.FluctuatingRateValueLabel.Text = "-";
                this.CountValueLabel.Text = "-";
                this.AmountValueLabel.Text = "-";
                this.UpdateTimeValueLabel.Text = "-";
            }
            else
            {
                this.CurrentPriceValueLabel.Text = quota.CurrentPrice.ToString("N4");
                this.FluctuatingRangeValueLabel.Text = quota.FluctuatingRange.ToString("N4");
                this.FluctuatingRateValueLabel.Text = quota.FluctuatingRate.ToString("N4");
                this.CountValueLabel.Text = quota.Count.ToString("N0");
                this.AmountValueLabel.Text = quota.Amount.ToString("N0");
                this.UpdateTimeValueLabel.Text = quota.UpdateTime.ToString();
            }
        }
    }
}
