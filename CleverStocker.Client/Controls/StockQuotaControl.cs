using System.Drawing;
using CleverStocker.Model;

namespace CleverStocker.Client.Controls
{
    /// <summary>
    /// 股票行情基本控件
    /// </summary>
    public partial class StockQuotaControl : StockAttachControlBaseGeneric<Quota>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockQuotaControl"/> class.
        /// </summary>
        public StockQuotaControl()
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
            this.ClosingPriceYesterdayLabel.ForeColor = color;
            this.OpeningPriceTodayLabel.ForeColor = color;
            this.DayHighPriceLabel.ForeColor = color;
            this.DayLowPriceLabel.ForeColor = color;
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
            this.ClosingPriceYesterdayValueLabel.ForeColor = color;
            this.OpeningPriceTodayValueLabel.ForeColor = color;
            this.DayHighPriceValueLabel.ForeColor = color;
            this.DayLowPriceValueLabel.ForeColor = color;
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
        public override void AttachEntityToFace(Quota quota)
        {
            if (quota == null)
            {
                this.CurrentPriceValueLabel.Text = "-";
                this.ClosingPriceYesterdayValueLabel.Text = "-";
                this.OpeningPriceTodayValueLabel.Text = "-";
                this.DayHighPriceValueLabel.Text = "-";
                this.DayLowPriceValueLabel.Text = "-";
                this.CountValueLabel.Text = "-";
                this.AmountValueLabel.Text = "-";
                this.UpdateTimeValueLabel.Text = "-";
            }
            else
            {
                this.CurrentPriceValueLabel.Text = quota.CurrentPrice.ToString("N4");
                this.ClosingPriceYesterdayValueLabel.Text = quota.ClosingPriceYesterday.ToString("N4");
                this.OpeningPriceTodayValueLabel.Text = quota.OpeningPriceToday.ToString("N4");
                this.DayHighPriceValueLabel.Text = quota.DayHighPrice.ToString("N4");
                this.DayLowPriceValueLabel.Text = quota.DayLowPrice.ToString("N4");
                this.CountValueLabel.Text = quota.Count.ToString("N0");
                this.AmountValueLabel.Text = quota.Amount.ToString("N0");
                this.UpdateTimeValueLabel.Text = quota.UpdateTime.ToString();
            }
        }
    }
}
