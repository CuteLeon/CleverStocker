using System;
using System.Collections.Generic;
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
            => this.Context.Set<Quota>()
                .Where(quota => quota.Code == code && quota.Market == market)
                .OrderByDescending(stock => stock.UpdateTime)
                .FirstOrDefault();

        /// <summary>
        /// 查询行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<Quota> QueryQuotas(string code, Markets market, DateTime? startDate, DateTime? endDate)
        {
            var quotas = this.Context.Set<Quota>()
                .Where(quota => quota.Code == code && quota.Market == market);

            if (startDate != null)
            {
                quotas = quotas.Where(quota => quota.UpdateTime >= startDate);
            }

            if (endDate != null)
            {
                quotas = quotas.Where(quota => quota.UpdateTime <= endDate);
            }

            return quotas.ToList();
        }
    }
}
