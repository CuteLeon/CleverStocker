using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 大盘指数
    /// </summary>
    public class MarketQuota : StockTimelyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuota"/> class.
        /// </summary>
        public MarketQuota()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuota"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        public MarketQuota(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarketQuota"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="updateTime"></param>
        public MarketQuota(string code, Markets market, DateTime updateTime)
            : base(code, market, updateTime)
        {
        }

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
        public long Count { get; set; } = -1L;

        /// <summary>
        /// Gets or sets 成交金额 (单位：万元)
        /// </summary>
        public long Amount { get; set; } = -1L;
        #endregion
    }
}
