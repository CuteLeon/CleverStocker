using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 股票基类
    /// </summary>
    public abstract class StockBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockBase"/> class.
        /// </summary>
        public StockBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockBase"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public StockBase(string code, Markets market)
        {
            this.Code = code;
            this.Market = market;
        }

        /// <summary>
        /// Gets or sets 代码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public virtual string Code { get; set; }

        /// <summary>
        /// Gets or sets 市场
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [Required]
        [Range(1, int.MaxValue)]
        public virtual Markets Market { get; set; }
    }
}
