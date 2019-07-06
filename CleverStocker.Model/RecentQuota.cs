using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 最近行情
    /// </summary>
    public class RecentQuota : StockTimelyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuota"/> class.
        /// </summary>
        public RecentQuota()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuota"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        public RecentQuota(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentQuota"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="updateTime"></param>
        public RecentQuota(string code, Markets market, DateTime updateTime)
            : base(code, market, updateTime)
        {
        }

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
