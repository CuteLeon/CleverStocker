using System;
using System.Collections.Generic;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Services
{
    /// <summary>
    /// 行情服务接口
    /// </summary>
    public interface IQuotaService : IPersistService<Quota>
    {
        /// <summary>
        /// 获取最后一条行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Quota GetLastQuota(string code, Markets market);

        /// <summary>
        /// 查询行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        List<Quota> QueryQuotas(string code, Markets market, DateTime? startDate, DateTime? endDate);
    }
}
