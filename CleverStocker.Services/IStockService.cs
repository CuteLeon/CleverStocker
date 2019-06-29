using System.Collections.Generic;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 股票接口
    /// </summary>
    public interface IStockService : IPersistService<Stock>
    {
        /// <summary>
        /// 获取自选股票
        /// </summary>
        /// <returns></returns>
        List<Stock> GetSelfSelectStocks();
    }
}
