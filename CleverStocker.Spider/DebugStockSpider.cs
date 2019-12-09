using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CleverStocker.Model;
using CleverStocker.Services;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Spider
{
    /// <summary>
    /// 调试股票爬虫服务
    /// </summary>
    public class DebugStockSpider : IStockSpiderService
    {
        /// <summary>
        /// 随机数发生器
        /// </summary>
        private readonly Random random = new Random();

        #region 行情

        /// <summary>
        /// 获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public (Stock Stock, Quota Quota) GetStockQuota(string code, Markets market)
            => (new Stock(code, market, code), new Quota(code, market, code) { CurrentPrice = (this.random.NextDouble() * 5) + 15 });

        /// <summary>
        /// 异步获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock Stock, Quota Quota)> GetStockQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockQuota(code, market));
        #endregion

        #region 大盘指数

        /// <summary>
        /// 获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public (Stock Stock, MarketQuota MarketQuota) GetStockMarketQuota(string code, Markets market)
            => (new Stock(code, market, code), new MarketQuota(code, market, code) { CurrentPrice = (this.random.NextDouble() * 5) + 15 });

        /// <summary>
        /// 异步获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock Stock, MarketQuota MarketQuota)> GetStockMarketQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockMarketQuota(code, market));
        #endregion

        #region 图表

        /// <summary>
        /// 获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        public Image GetChart(string code, Markets market, Charts chart)
            => new Bitmap(100, 100);

        /// <summary>
        /// 异步获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        public async Task<Image> GetChartAsync(string code, Markets market, Charts chart)
            => await Task.Factory.StartNew(() => this.GetChart(code, market, chart));
        #endregion

        #region 公司信息

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public Company GetCompany(string code, Markets market)
            => new Company(code, market, code);

        /// <summary>
        /// 异步获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<Company> GetCompanyAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetCompany(code, market));
        #endregion

        #region 最近行情

        /// <summary>
        /// 获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<RecentQuota> GetRecentQuotas(string code, Markets market, TimeScales timeScale, int count)
            => Enumerable.Range(1, count).Select(index => new RecentQuota(code, market, code, DateTime.Now.AddMinutes(index))).ToList();

        /// <summary>
        /// 异步获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<RecentQuota>> GetRecentQuotasAsync(string code, Markets market, TimeScales timeScale, int count)
            => await Task.Factory.StartNew(() => this.GetRecentQuotas(code, market, timeScale, count));
        #endregion

        #region 最近交易

        /// <summary>
        /// 获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Trade> GetRecentTrades(string code, Markets market, TradeListTypes tradeListType, int count)
            => Enumerable.Range(1, count).Select(index => new Trade(code, market, code, DateTime.Now.AddMinutes(index))).ToList();

        /// <summary>
        /// 异步获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="markets"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Trade>> GetRecentTradesAsync(string code, Markets markets, TradeListTypes tradeListType, int count)
            => await Task.Factory.StartNew(() => this.GetRecentTrades(code, markets, tradeListType, count));
        #endregion

        #region 热门股票

        /// <summary>
        /// 获取热门股票
        /// </summary>
        /// <returns></returns>
        public List<Stock> GetHotStocks()
            => Enumerable.Range(1, 20).Select(index => new Stock(index.ToString().PadLeft(6, '0'), Markets.ShangHai)).ToList();

        /// <summary>
        /// 异步获取热门股票
        /// </summary>
        /// <returns></returns>
        public async Task<List<Stock>> GetHotStocksAsync()
            => await Task.Factory.StartNew(() => this.GetHotStocks());
        #endregion

        #region 搜索股票

        /// <summary>
        /// 使用关键字搜索股票
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Stock> GetSearchStocks(string keyword)
            => Enumerable.Range(1, 10).Select(index => new Stock($"{keyword}{index}".PadRight(6, '0'), Markets.ShangHai)).ToList();

        /// <summary>
        /// 异步使用关键字搜索股票
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<Stock>> GetSearchStocksAsync(string keyword)
            => await Task.Factory.StartNew(() => this.GetSearchStocks(keyword));
        #endregion
    }
}
