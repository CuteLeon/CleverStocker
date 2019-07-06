using System;
using System.Collections.Generic;

namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 股票基类比较器
    /// </summary>
    /// <typeparam name="TStockBase">股票基类</typeparam>
    public class StockBaseComparer<TStockBase> : IEqualityComparer<TStockBase>, IComparer<TStockBase>
        where TStockBase : StockBase
    {
        /// <summary>
        /// 比较大小
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual int Compare(TStockBase x, TStockBase y)
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
        public virtual bool Equals(TStockBase x, TStockBase y)
        => ReferenceEquals(x, y) ||
            (string.Compare(x?.Code, y?.Code, StringComparison.OrdinalIgnoreCase) == 0 &&
            x?.Market == y?.Market);

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int GetHashCode(TStockBase obj)
            => obj.GetHashCode();
    }
}
