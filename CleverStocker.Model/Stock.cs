using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets 市场
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [Required]
        public string Market { get; set; }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }
    }
}
