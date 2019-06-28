using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 交易
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        public Trade()
        {
        }

        /// <summary>
        /// Gets or sets 日期时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets 交易方向
        /// </summary>
        public TradeTypes TradeType { get; set; }

        /// <summary>
        /// Gets or sets 交易量
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets 交易价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets 交易量占比
        /// </summary>
        public double Rate { get; set; }
    }
}
