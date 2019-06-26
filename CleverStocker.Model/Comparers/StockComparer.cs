using System.Collections.Generic;

namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 股票相等比较器
    /// </summary>
    public class StockComparer : IEqualityComparer<Stock>
    {
        /// <summary>
        /// 判断股票相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Stock x, Stock y)
        => string.Compare(x?.Code, y.Code) == 0 &&
            x?.Market == y?.Market;

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Stock obj)
            => obj.GetHashCode();
    }
}
