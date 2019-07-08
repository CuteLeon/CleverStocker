using System.Drawing;
using CleverStocker.Model;
using CleverStocker.Utils;

namespace CleverStocker.Client.Controls
{
    /// <summary>
    /// 股票行情五档盘口控件
    /// </summary>
    public partial class StockQuotaFiveGearControl : StockAttachControlBaseGeneric<Quota>, IStockAttachControlBaseGeneric<Quota>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockQuotaFiveGearControl"/> class.
        /// </summary>
        public StockQuotaFiveGearControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 设置标签前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetLabelForecolor(Color color)
        {
            this.BiddingPriceLabel.ForeColor = color;
            this.AuctionPriceLabel.ForeColor = color;

            this.Buy1Label.ForeColor = color;
            this.Buy2Label.ForeColor = color;
            this.Buy3Label.ForeColor = color;
            this.Buy4Label.ForeColor = color;
            this.Buy5Label.ForeColor = color;

            this.Sell1Label.ForeColor = color;
            this.Sell2Label.ForeColor = color;
            this.Sell3Label.ForeColor = color;
            this.Sell4Label.ForeColor = color;
            this.Sell5Label.ForeColor = color;
        }

        /// <summary>
        /// 设置值前景色
        /// </summary>
        /// <param name="color"></param>
        public override void SetValueForecolor(Color color)
        {
            this.BiddingPriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.AuctionPriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);

            this.Buy1StrandValueLabel.ForeColor = color;
            this.Buy2StrandValueLabel.ForeColor = color;
            this.Buy3StrandValueLabel.ForeColor = color;
            this.Buy4StrandValueLabel.ForeColor = color;
            this.Buy5StrandValueLabel.ForeColor = color;

            this.Buy1PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.Buy2PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.Buy3PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.Buy4PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);
            this.Buy5PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(1);

            this.Sell1StrandValueLabel.ForeColor = color;
            this.Sell2StrandValueLabel.ForeColor = color;
            this.Sell3StrandValueLabel.ForeColor = color;
            this.Sell4StrandValueLabel.ForeColor = color;
            this.Sell5StrandValueLabel.ForeColor = color;

            this.Sell1PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
            this.Sell2PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
            this.Sell3PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
            this.Sell4PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
            this.Sell5PriceValueLabel.ForeColor = ThemeHelper.GetQuotaForecolor(-1);
        }

        /// <summary>
        /// 应用行情数据到界面
        /// </summary>
        /// <param name="quota"></param>
        public override void AttachEntityToFace(Quota quota)
        {
            if (quota == null)
            {
                this.BiddingPriceValueLabel.Text = "-";
                this.AuctionPriceValueLabel.Text = "-";

                this.Buy1StrandValueLabel.Text = "-";
                this.Buy2StrandValueLabel.Text = "-";
                this.Buy3StrandValueLabel.Text = "-";
                this.Buy4StrandValueLabel.Text = "-";
                this.Buy5StrandValueLabel.Text = "-";

                this.Buy1PriceValueLabel.Text = "-";
                this.Buy2PriceValueLabel.Text = "-";
                this.Buy3PriceValueLabel.Text = "-";
                this.Buy4PriceValueLabel.Text = "-";
                this.Buy5PriceValueLabel.Text = "-";

                this.Sell1StrandValueLabel.Text = "-";
                this.Sell2StrandValueLabel.Text = "-";
                this.Sell3StrandValueLabel.Text = "-";
                this.Sell4StrandValueLabel.Text = "-";
                this.Sell5StrandValueLabel.Text = "-";

                this.Sell1PriceValueLabel.Text = "-";
                this.Sell2PriceValueLabel.Text = "-";
                this.Sell3PriceValueLabel.Text = "-";
                this.Sell4PriceValueLabel.Text = "-";
                this.Sell5PriceValueLabel.Text = "-";
            }
            else
            {
                this.BiddingPriceValueLabel.Text = quota.BiddingPrice.ToString("N4");
                this.AuctionPriceValueLabel.Text = quota.AuctionPrice.ToString("N4");

                this.Buy1StrandValueLabel.Text = quota.BuyStrand1.ToString("N0");
                this.Buy2StrandValueLabel.Text = quota.BuyStrand2.ToString("N0");
                this.Buy3StrandValueLabel.Text = quota.BuyStrand3.ToString("N0");
                this.Buy4StrandValueLabel.Text = quota.BuyStrand4.ToString("N0");
                this.Buy5StrandValueLabel.Text = quota.BuyStrand5.ToString("N0");

                this.Buy1PriceValueLabel.Text = quota.BuyPrice1.ToString("N2");
                this.Buy2PriceValueLabel.Text = quota.BuyPrice2.ToString("N2");
                this.Buy3PriceValueLabel.Text = quota.BuyPrice3.ToString("N2");
                this.Buy4PriceValueLabel.Text = quota.BuyPrice4.ToString("N2");
                this.Buy5PriceValueLabel.Text = quota.BuyPrice5.ToString("N2");

                this.Sell1StrandValueLabel.Text = quota.SellStrand1.ToString("N0");
                this.Sell2StrandValueLabel.Text = quota.SellStrand2.ToString("N0");
                this.Sell3StrandValueLabel.Text = quota.SellStrand3.ToString("N0");
                this.Sell4StrandValueLabel.Text = quota.SellStrand4.ToString("N0");
                this.Sell5StrandValueLabel.Text = quota.SellStrand5.ToString("N0");

                this.Sell1PriceValueLabel.Text = quota.SellPrice1.ToString("N2");
                this.Sell2PriceValueLabel.Text = quota.SellPrice2.ToString("N2");
                this.Sell3PriceValueLabel.Text = quota.SellPrice3.ToString("N2");
                this.Sell4PriceValueLabel.Text = quota.SellPrice4.ToString("N2");
                this.Sell5PriceValueLabel.Text = quota.SellPrice5.ToString("N2");
            }
        }
    }
}
