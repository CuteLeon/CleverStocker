using System;
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
        /// <param name="code"></param>
        /// <param name="market"></param>
        public Stock(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="name"></param>
        public Stock(string code, Markets market, string name)
            : this(code, market)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 自选股票
        /// </summary>
        public bool IsSelfSelect { get; set; }
    }
}
