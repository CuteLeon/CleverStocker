using CleverStocker.Model;

namespace CleverStocker.ML.NextOpenPrice
{
    public class NOPInput : RecentQuota
    {
        /// <summary>
        /// Gets or sets 下次开盘价格 (元)
        /// </summary>
        public double NextOpenningPrice { get; set; }
    }
}
