using System.Collections.Generic;
using System.Xml.Serialization;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 股票
    /// </summary>
    public class Stock : StockBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        public Stock()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public Stock(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        public Stock(string code, Markets market, string name)
            : base(code, market, name)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether 自选股票
        /// </summary>
        public bool IsSelfSelect { get; set; }

        #region 关联实体

        /// <summary>
        /// Gets or sets 公司
        /// </summary>
        [XmlIgnore]
        public virtual Company Company { get; set; }

        /// <summary>
        /// Gets or sets 行情
        /// </summary>
        [XmlIgnore]
        public virtual List<Quota> Quotas { get; set; } = new List<Quota>();

        /// <summary>
        /// Gets or sets 大盘指数
        /// </summary>
        [XmlIgnore]
        public virtual List<MarketQuota> MarketQuotas { get; set; } = new List<MarketQuota>();

        /// <summary>
        /// Gets or sets 最近行情
        /// </summary>
        [XmlIgnore]
        public virtual List<RecentQuota> RecentQuotas { get; set; } = new List<RecentQuota>();
        #endregion
    }
}
