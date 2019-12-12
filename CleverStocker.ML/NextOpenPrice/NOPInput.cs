namespace CleverStocker.ML.NextOpenPrice
{
    public class NOPInput
    {
        /// <summary>
        /// Gets or sets 开盘价格 (元)
        /// </summary>
        public float OpenningPrice { get; set; }

        /// <summary>
        /// Gets or sets 收盘价格 (元)
        /// </summary>
        public float ClosingPrice { get; set; }

        /// <summary>
        /// Gets or sets 最高价格 (元)
        /// </summary>
        public float HighestPrice { get; set; }

        /// <summary>
        /// Gets or sets 最低价格 (元)
        /// </summary>
        public float LowestPrice { get; set; }

        /// <summary>
        /// Gets or sets 成交数量 (股)
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets 下次开盘价格 (元)
        /// </summary>
        public float NextOpenningPrice { get; set; }
    }
}
