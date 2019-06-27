using System;
using System.ComponentModel.DataAnnotations;

namespace CleverStocker.Model
{
    /// <summary>
    /// 行情
    /// </summary>
    public class Quota
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        public Quota()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        /// <param name="stock"></param>
        public Quota(Stock stock)
            : this()
        {
            this.Stock = stock;
        }

        /// <summary>
        /// Gets or sets iD
        /// </summary>
        [Key]
        [Required]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [Required]
        public Stock Stock { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
