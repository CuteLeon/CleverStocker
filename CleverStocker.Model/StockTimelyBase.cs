using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 股票时效性基类
    /// </summary>
    public class StockTimelyBase : StockBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockTimelyBase"/> class.
        /// </summary>
        public StockTimelyBase()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockTimelyBase"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public StockTimelyBase(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockTimelyBase"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="updateTime">更新时间</param>
        public StockTimelyBase(string code, Markets market, DateTime updateTime)
            : this(code, market)
        {
            this.UpdateTime = updateTime;
        }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [Required]
        public DateTime UpdateTime { get; set; }
    }
}
