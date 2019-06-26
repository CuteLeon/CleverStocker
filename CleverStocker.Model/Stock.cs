using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 股票
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        public Stock()
        {
        }

        /// <summary>
        /// Gets or sets 代码
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets 市场
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [Required]
        [Range(1, int.MaxValue)]
        public Markets Market { get; set; }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets 行情
        /// </summary>
        public virtual List<Quota> Quotas { get; set; }
    }
}
