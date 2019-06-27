using System.Collections.Generic;
using System.Threading.Tasks;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IStockSpiderService
    {
        IEnumerable<Stock> GetStocks();

        Task<IEnumerable<Stock>> GetStocksAsync();

        Stock GetStock(string code, Markets market);

        Task<Stock> GetStockAsync(string code, Markets market);
    }
}
