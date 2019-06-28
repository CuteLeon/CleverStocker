using System.Collections.Generic;
using System.Drawing;
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

        /// <summary>
        /// 获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        (Stock stock, MarketQuota marketQuota) GetStockMarketQuota(string code, Markets market);

        /// <summary>
        /// 异步获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Task<(Stock stock, MarketQuota marketQuota)> GetStockMarketQuotaAsync(string code, Markets market);

        /// <summary>
        /// 获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        Image GetChart(string code, Markets market, Charts chart);

        /// <summary>
        /// 异步获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        Task<Image> GetChartAsync(string code, Markets market, Charts chart);

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Company GetCompany(string code, Markets market);

        /// <summary>
        /// 异步获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Task<Company> GetCompanyAsync(string code, Markets market);

        /// <summary>
        /// 获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<RecentQuota> GetRecentQuotas(string code, Markets market, TimeScales timeScale, int count);

        /// <summary>
        /// 异步获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<RecentQuota>> GetRecentQuotasAsync(string code, Markets market, TimeScales timeScale, int count);
    }
}
