using System;
using System.Collections.Generic;

namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 大盘指数比较器
    /// </summary>
    public class MarketQuotaComparer : IEqualityComparer<MarketQuota>, IComparer<MarketQuota>
    {
        /// <summary>
        /// 股票比较器
        /// </summary>
        private readonly StockComparer stockComparer = new StockComparer();

        /// <summary>
        /// 比较大小
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(MarketQuota x, MarketQuota y)
        {
            if (this.stockComparer.Equals(x?.Stock, y?.Stock))
            {
                return x?.UpdateTime > y?.UpdateTime ? 1 : -1;
            }
            else
            {
                return this.stockComparer.Compare(x?.Stock, y?.Stock);
            }
        }

        /// <summary>
        /// 比较相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(MarketQuota x, MarketQuota y)
            => ReferenceEquals(x, y) ||
                (string.Compare(x?.ID, y?.ID, StringComparison.OrdinalIgnoreCase) == 0) ||
                (this.stockComparer.Equals(x?.Stock, y?.Stock) &&
                x?.UpdateTime == y?.UpdateTime);

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(MarketQuota obj)
            => obj.GetHashCode();
    }
}
