using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 股票基类
    /// </summary>
    /// <remarks>模型类需要给部分引用成员增加 [XmlIgnore] 特性以避免序列化异常</remarks>
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
        /// Initializes a new instance of the <see cref="StockBase"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        public StockBase(string code, Markets market, string name)
        {
            this.Code = code;
            this.Market = market;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets 代码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "股票代码不允许为空")]
        [MinLength(5, ErrorMessage = "股票代码长度不允许少于5位")]
        [MaxLength(6, ErrorMessage = "股票代码长度不允许多于6位")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets 市场
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "股票市场不允许为空")]
        [Range(1, int.MaxValue, ErrorMessage = "不允许保存未知市场的股票")]
        public Markets Market { get; set; }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"{this.Name} ({this.Market}-{this.Code})";
    }
}
