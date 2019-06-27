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

        public Stock GetStock(string code, Markets market)
        {
            if (!MarketDictionary.TryGetValue(market, out var marketInfo) ||
               string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            string request = $@"http://hq.sinajs.cn/list={marketInfo.Code}{code}";
            // this.WebClient.DownloadString(request);
            var result = @"var hq_str_sh600086=""东方金钰,4.380,4.510,4.400,4.450,4.320,4.390,4.400,24027903,105284470.000,108305,4.390,169929,4.380,371500,4.370,423400,4.360,434900,4.350,17200,4.400,58700,4.410,32500,4.420,37900,4.430,80700,4.440,2019-06-27,09:58:11,00"";";

            if (string.IsNullOrEmpty(result))
            {
                return default;
            }

            var match = this.StockRegex.Match(result);
            if (!match.Success)
            {
                return default;
            }

            _ = match.Groups["Name"].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;
            _ = match.Groups[""].Value;

            Stock stock = new Stock(code, market);

            return stock;
        }

        public async Task<Stock> GetStockAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStock(code, market));
    }
}
