using System.Linq;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 行情服务
    /// </summary>
    public class QuotaService : PersistServiceBase<Quota>, IQuotaService
    {
        /// <summary>
        /// 获取最后一条行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public Quota GetLastQuota(string code, Markets market)
            => this.Context.Set<Quota>().OrderByDescending(stock => stock.UpdateTime).First();
    }
}
