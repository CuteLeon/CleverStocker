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
        /// Gets or sets iD
        /// </summary>
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        public Stock Stock { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
