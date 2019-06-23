using System.Collections.Generic;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 股票接口
    /// </summary>
    public interface IStockerService
    {
        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<Stock> GetStocks();

        /// <summary>
        /// 添加股票
        /// </summary>
        /// <param name="stock"></param>
        void AddStock(Stock stock);
    }
}
