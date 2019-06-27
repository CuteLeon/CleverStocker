using System;
using System.Collections.Generic;

namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 股票比较器
    /// </summary>
    public class StockComparer : IEqualityComparer<Stock>, IComparer<Stock>
    {
        /// <summary>
        /// 比较大小
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(Stock x, Stock y)
        {
            if (x?.Market == y?.Market)
            {
                return string.Compare(x?.Code, y?.Code, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return x?.Market > y?.Market ? 1 : -1;
            }
        }

        /// <summary>
        /// 判断股票相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Stock x, Stock y)
        => ReferenceEquals(x, y) ||
            (string.Compare(x?.Code, y?.Code, StringComparison.OrdinalIgnoreCase) == 0 &&
            x?.Market == y?.Market);

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Stock obj)
            => obj.GetHashCode();
    }
}
