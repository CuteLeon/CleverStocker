using System.Xml.Serialization;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company : StockBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public Company(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        public Company(string code, Markets market, string name)
            : base(code, market, name)
        {
        }

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [XmlIgnore]
        public virtual Stock Stock { get; set; }

        /// <summary>
        /// Gets or sets 评级
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets 投票
        /// </summary>
        public int Vote { get; set; }

        /// <summary>
        /// Gets or sets 位置
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets 概要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets 行业
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Gets or sets 简介
        /// </summary>
        public string Brief { get; set; }

        /// <summary>
        /// Gets or sets 状态
        /// </summary>
        public string Status { get; set; }
    }
}
