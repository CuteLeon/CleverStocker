using System;

namespace CleverStocker.Model
{
    /// <summary>
    /// 最近行情
    /// </summary>
    public class RecentQuota
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuota"/> class.
        /// </summary>
        public RecentQuota()
        {
        }

        /// <summary>
        /// Gets or sets 日期时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets 开盘价格 (元)
        /// </summary>
        public double OpenningPrice { get; set; }

        /// <summary>
        /// Gets or sets 收盘价格 (元)
        /// </summary>
        public double ClosingPrice { get; set; }

        /// <summary>
        /// Gets or sets 最高价格 (元)
        /// </summary>
        public double HighestPrice { get; set; }

        /// <summary>
        /// Gets or sets 最低价格 (元)
        /// </summary>
        public double LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets 成交数量 (股)
        /// </summary>
        public long Volume { get; set; }
    }
}
