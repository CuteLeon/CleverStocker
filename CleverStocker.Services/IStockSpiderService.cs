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
        /// <summary>
        /// 获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        (Stock stock, Quota quota) GetStockQuota(string code, Markets market);

        /// <summary>
        /// 异步获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Task<(Stock stock, Quota quota)> GetStockQuotaAsync(string code, Markets market);
    }
}
