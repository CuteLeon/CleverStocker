using System;
using System.ComponentModel.DataAnnotations;

namespace CleverStocker.Model
{
    /// <summary>
    /// 大盘指数
    /// </summary>
    public class MarketQuota
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuota"/> class.
        /// </summary>
        public MarketQuota()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuota"/> class.
        /// </summary>
        /// <param name="stock"></param>
        public MarketQuota(Stock stock)
            : this()
        {
            this.Stock = stock;
        }

        /// <summary>
        /// Gets or sets iD
        /// </summary>
        [Key]
        [Required]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [Required]
        public virtual Stock Stock { get; set; }

        #region 大盘指数

        /// <summary>
        /// Gets or sets 当前价格 (单位：元)
        /// </summary>
        public double CurrentPrice { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets 涨跌幅度（单位：元）
        /// </summary>
        public double FluctuatingRange { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets 涨跌比率（单位：%）
        /// </summary>
        public double FluctuatingRate { get; set; } = double.NaN;

        /// <summary>
        /// Gets or sets 成交股票数量 (单位：手)
        /// </summary>
        public long Count { get; set; } = long.MinValue;

        /// <summary>
        /// Gets or sets 成交金额 (单位：万元)
        /// </summary>
        public long Amount { get; set; } = long.MinValue;
        #endregion

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
