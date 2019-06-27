using System;
using System.Collections.Generic;

namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 行情相等比较器
    /// </summary>
    public class QuotaComparer : IEqualityComparer<Quota>, IComparer<Quota>
    {
        /// <summary>
        /// 股票比较器
        /// </summary>
        private readonly StockComparer stockComparer = new StockComparer();

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Quota x, Quota y)
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
        /// 相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <remarks>行情ID相同或同一债券同一时刻的更新</remarks>
        public bool Equals(Quota x, Quota y)
            => ReferenceEquals(x, y) ||
                (string.Compare(x?.ID, y?.ID, StringComparison.OrdinalIgnoreCase) == 0) ||
                (this.stockComparer.Equals(x?.Stock, y?.Stock) &&
                x?.UpdateTime == y?.UpdateTime);

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Quota obj)
            => obj.GetHashCode();
    }
}
