using System.Drawing;
using CleverStocker.Model;
using CleverStocker.Utils;

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

            if (this.DesignMode)
            {
                return;
            }
        }

        /// <summary>
        /// 设置标签前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetLabelForecolor(Color color)
        {
            this.DayHighPriceLabel.ForeColor = color;
            this.DayLowPriceLabel.ForeColor = color;
            this.ClosingPriceYesterdayLabel.ForeColor = color;
            this.OpeningPriceTodayLabel.ForeColor = color;
            this.CountLabel.ForeColor = color;
            this.AmountLabel.ForeColor = color;

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
            this.CurrentPriceValueLabel.StaticForecolor = color;
            this.ClosingPriceYesterdayValueLabel.ForeColor = color;
            this.OpeningPriceTodayValueLabel.ForeColor = color;
            this.DayHighPriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.DayLowPriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
            this.CountValueLabel.ForeColor = color;
            this.AmountValueLabel.ForeColor = color;
        }

        /// <summary>
        /// 应用股票数据到界面
        /// </summary>
        /// <param name="stock"></param>
        /// <remarks>股票变化时，需要清除价格控件的价格数据，以避免不同股票的价格比较</remarks>
        public override void StockToFace(Stock stock)
        {
            this.CurrentPriceValueLabel.ClearPrice();

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
                this.CurrentPriceValueLabel.Price = double.NaN;
                this.OpeningPriceTodayValueLabel.ForeColor = this.ValueForecolor;
                this.ClosingPriceYesterdayValueLabel.ForeColor = this.ValueForecolor;

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
                if (quota.OpeningPriceToday > quota.ClosingPriceYesterday)
                {
                    this.OpeningPriceTodayValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
                    this.ClosingPriceYesterdayValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
                }
                else
                {
                    this.OpeningPriceTodayValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
                    this.ClosingPriceYesterdayValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
                }

                this.CurrentPriceValueLabel.BasePrice = quota.OpeningPriceToday;
                this.CurrentPriceValueLabel.Price = quota.CurrentPrice;
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
