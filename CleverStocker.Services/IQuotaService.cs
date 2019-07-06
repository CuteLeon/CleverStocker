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
    }
}
