using System.Collections.Generic;
using System.Linq;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 股票服务
    /// </summary>
    public class StockService : PersistServiceBase<Stock>, IStockService
    {
        /// <summary>
        /// 获取自选股票
        /// </summary>
        /// <returns></returns>
        public List<Stock> GetSelfSelectStocks()
            => this.Context.Set<Stock>().Where(stock => stock.IsSelfSelect).ToList();
    }
}
