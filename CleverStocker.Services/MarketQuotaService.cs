using System.Linq;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 大盘行情服务
    /// </summary>
    public class MarketQuotaService : PersistServiceBase<MarketQuota>, IMarketQuotaService
    {
        /// <summary>
        /// 获取最后一条行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public MarketQuota GetLastMarketQuota(string code, Markets market)
            => this.Context.Set<MarketQuota>()
                .Where(quota => quota.Code == code && quota.Market == market)
                .OrderByDescending(stock => stock.UpdateTime)
                .FirstOrDefault();
    }
}
