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
        /// <param name="name">名称</param>
        public StockTimelyBase(string code, Markets market, string name)
            : base(code, market, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockTimelyBase"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        /// <param name="updateTime">更新时间</param>
        public StockTimelyBase(string code, Markets market, string name, DateTime updateTime)
            : this(code, market, name)
        {
            this.UpdateTime = updateTime;
        }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "股票相关信息需要确定的更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
