using System.Collections.Generic;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 服务抽象基类
    /// </summary>
    public abstract class StockerServiceBase : IStockerService
    {
        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<Stock> GetStocks();
    }
}
