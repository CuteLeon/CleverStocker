using System.Collections.Generic;
using System.Threading.Tasks;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IStockerSpiderService
    {
        IEnumerable<Stock> GetStocks();

        Task<IEnumerable<Stock>> GetStocksAsync();

        Stock GetStock(Markets market, string code);

        Task<Stock> GetStockAsync(Markets market, string code);
    }
}
