using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 大盘行情服务
    /// </summary>
    public interface IMarketQuotaService : IPersistService<MarketQuota>
    {
        /// <summary>
        /// 获取最后一条行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        MarketQuota GetLastMarketQuota(string code, Markets market);
    }
}
