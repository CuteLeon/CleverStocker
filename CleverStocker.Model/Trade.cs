using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 交易
    /// </summary>
    public class Trade : StockTimelyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        public Trade()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public Trade(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        public Trade(string code, Markets market, string name)
            : base(code, market, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        /// <param name="updateTime">更新时间</param>
        public Trade(string code, Markets market, string name, DateTime updateTime)
            : base(code, market, name, updateTime)
        {
        }

        /// <summary>
        /// Gets or sets 交易方向
        /// </summary>
        public TradeTypes TradeType { get; set; }

        /// <summary>
        /// Gets or sets 交易量 (单位 股)
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets 交易价格 (单位 元)
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets 交易量占比 (单位 %)
        /// </summary>
        public double Rate { get; set; }
    }
}
