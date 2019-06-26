using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SinaStockSpider : SpiderClientBase, IStockerSpiderService
    {
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

            return default;
        }

        public async Task<Stock> GetStockAsync(Markets market, string code)
            => await Task.Factory.StartNew(() => this.GetStock(market, code));
    }
}
