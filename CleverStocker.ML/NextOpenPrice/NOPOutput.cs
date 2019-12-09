using Microsoft.ML.Data;

namespace CleverStocker.ML.NextOpenPrice
{
    /// <summary>
    /// NOP输出模型
    /// </summary>
    public class NOPOutput
    {
        /// <summary>
        /// Gets or sets 分数
        /// </summary>
        [ColumnName("Score")]
        public float NextOpenPrice { get; set; }
    }
}
