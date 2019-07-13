using System;
using System.Drawing;
using System.Windows.Forms;
using CleverStocker.Utils;

namespace CleverStocker.Client.Controls
{
    /// <summary>
    /// 价格控件
    /// </summary>
    public class PriceControl : Label
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceControl"/> class.
        /// </summary>
        public PriceControl()
        {
            this.AutoEllipsis = true;
            this.Dock = DockStyle.Fill;
            this.Font = new Font("微软雅黑", 20F, FontStyle.Bold);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(0);
            this.Text = "-";
            this.TextAlign = ContentAlignment.MiddleCenter;

            this.ImageList = new ImageList();
            this.ImageList.Images.Add(AppResource.StaticStatus);
            this.ImageList.Images.Add(AppResource.UpArrow);
            this.ImageList.Images.Add(AppResource.DownArrow);
            this.ImageIndex = 0;
        }

        #region 外观属性

        private Color staticForecolor = Color.Black;

        /// <summary>
        /// Gets or sets 价格静止颜色
        /// </summary>
        public Color StaticForecolor
        {
            get => this.staticForecolor;
            set
            {
                if (this.staticForecolor != value)
                {
                    this.staticForecolor = value;
                    this.RefreshPrice();
                }
            }
        }

        private Color riseForeColor = ThemeHelper.GetQuotaForecolor(1);

        /// <summary>
        /// Gets or sets 价格上涨颜色
        /// </summary>
        public Color RiseForeColor
        {
            get => this.riseForeColor;
            set
            {
                if (this.riseForeColor != value)
                {
                    this.riseForeColor = value;
                    this.RefreshPrice();
                }
            }
        }

        private Color fallForeColor = ThemeHelper.GetQuotaForecolor(-1);

        /// <summary>
        /// Gets or sets 价格下跌颜色
        /// </summary>
        public Color FallForeColor
        {
            get => this.fallForeColor;
            set
            {
                if (this.fallForeColor != value)
                {
                    this.fallForeColor = value;
                    this.RefreshPrice();
                }
            }
        }
        #endregion

        #region 价格属性

        /// <summary>
        /// 上次价格
        /// </summary>
        private double lastPrice = double.NaN;

        private byte accuracy = 4;
        private string priceFormat = "N4";

        /// <summary>
        /// Gets or sets 数据精度
        /// </summary>
        public byte Accuracy
        {
            get => this.accuracy;
            set
            {
                value = Math.Max((byte)0, value);

                if (this.accuracy != value)
                {
                    this.accuracy = value;
                    this.priceFormat = $"N{value}";
                    this.RefreshPrice();
                }
            }
        }

        private double basePrice = 0.0D;

        /// <summary>
        /// Gets or sets 基础价格
        /// </summary>
        public double BasePrice
        {
            get => this.basePrice;
            set
            {
                if (this.basePrice != value)
                {
                    this.basePrice = value;
                    this.RefreshPrice();
                }
            }
        }

        private double price = double.NaN;

        /// <summary>
        /// Gets or sets 价格
        /// </summary>
        public double Price
        {
            get => this.price;
            set
            {
                this.lastPrice = this.price;
                this.price = value;
                this.RefreshPrice();
            }
        }
        #endregion

        /// <summary>
        /// 清除价格
        /// </summary>
        public void ClearPrice()
        {
            this.lastPrice = double.NaN;
            this.Price = double.NaN;
        }

        /// <summary>
        /// 刷新价格
        /// </summary>
        public void RefreshPrice()
        {
            Console.WriteLine($"刷新界面，价格 = {this.Price}");
            if (double.IsNaN(this.Price))
            {
                this.Text = "-";
                this.ForeColor = this.StaticForecolor;
                this.ImageIndex = 0;
            }
            else
            {
                this.Text = this.Price.ToString(this.priceFormat);
                this.ForeColor = this.Price > this.BasePrice ? this.RiseForeColor : this.Price < this.BasePrice ? this.FallForeColor : this.StaticForecolor;
                this.ImageIndex = double.IsNaN(this.lastPrice) ? 0 : this.Price > this.lastPrice ? 1 : this.Price < this.lastPrice ? 2 : 0;
            }
        }
    }
}
