﻿using System.Collections.Generic;
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
        (Stock Stock, Quota Quota) GetStockQuota(string code, Markets market);

        /// <summary>
        /// 异步获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Task<(Stock Stock, Quota Quota)> GetStockQuotaAsync(string code, Markets market);

        /// <summary>
        /// 获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        (Stock Stock, MarketQuota MarketQuota) GetStockMarketQuota(string code, Markets market);

        /// <summary>
        /// 异步获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        Task<(Stock Stock, MarketQuota MarketQuota)> GetStockMarketQuotaAsync(string code, Markets market);

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

        /// <summary>
        /// 获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<Trade> GetRecentTrades(string code, Markets market, TradeListTypes tradeListType, int count);

        /// <summary>
        /// 异步获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<Trade>> GetRecentTradesAsync(string code, Markets market, TradeListTypes tradeListType, int count);

        /// <summary>
        /// 获取热门股票
        /// </summary>
        /// <returns></returns>
        List<Stock> GetHotStocks();

        /// <summary>
        /// 异步获取热门股票
        /// </summary>
        /// <returns></returns>
        Task<List<Stock>> GetHotStocksAsync();

        /// <summary>
        /// 使用关键字搜索股票
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        List<Stock> GetSearchStocks(string keyword);

        /// <summary>
        /// 异步使用关键字搜索股票
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        Task<List<Stock>> GetSearchStocksAsync(string keyword);
    }
}
