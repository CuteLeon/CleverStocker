using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company : StockTimelyBase
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
        /// <param name="code"></param>
        /// <param name="market"></param>
        public Company(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="updateTime"></param>
        public Company(string code, Markets market, DateTime updateTime)
            : base(code, market, updateTime)
        {
        }

        /// <summary>
        /// Gets or sets 评级
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets 投票
        /// </summary>
        public int Vote { get; set; }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }

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
