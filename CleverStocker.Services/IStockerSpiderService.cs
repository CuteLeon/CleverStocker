using System.Collections.Generic;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IStockerSpiderService
    {
        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<Stock> GetStocks();
    }
}
