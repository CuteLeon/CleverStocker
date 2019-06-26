using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Spider.SpiderClients;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Spider.Sina
{
    /// <summary>
    /// 新浪股票爬虫
    /// </summary>
    public class SinaStockSpider : SpiderClientBase, IStockSpiderService
    {
        // TODO: 实现 Sina 爬虫

        /// <summary>
        /// Gets 股票正则
        /// </summary>
        public Regex StockRegex { get; } = new Regex(
            $@"var\s.*\=""(?<Name>.*?),{string.Join(",", Enumerable.Range(1, 7).Select(index => $@"(?<Price{index}>[\d\.]+?)"))},(?<Amount1>\d+?),(?<Amount2>[\d\.]+?),{string.Join(",", Enumerable.Range(1, 10).Select(index => $@"(?<Strand{index}>\d+?),(?<Quote{index}>[\d\.]+?)"))},(?<DateTime>\d{{4}}-\d{{2}}-\d{{2}},\d{{2}}:\d{{2}}:\d{{2}}),00,"";",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        public IEnumerable<Stock> GetStocks()
            => Enumerable.Range(0, 10).Select(index => new Stock());

        public async Task<IEnumerable<Stock>> GetStocksAsync()
            => await Task.Factory.StartNew(() => this.GetStocks());

        public Stock GetStock(Markets market, string code)
        {
            if (!MarketDictionary.TryGetValue(market, out var marketInfo) ||
               string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            string request = $@"http://hq.sinajs.cn/list={marketInfo.Code}{code}";
            var result = this.WebClient.DownloadString(request);
            if (string.IsNullOrEmpty(result))
            {
                return default;
            }

            var match = this.StockRegex.Match(result);
            if (!match.Success)
            {
                return default;
            }

            Stock stock = new Stock();

            return stock;
        }

        public async Task<Stock> GetStockAsync(Markets market, string code)
            => await Task.Factory.StartNew(() => this.GetStock(market, code));
    }
}
