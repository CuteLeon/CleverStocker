using System.Collections.Generic;
using System.Linq;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Spider.HtmlAgilityPack;

namespace CleverStocker.Spider.Sina
{
    /// <summary>
    /// 新浪股票爬虫
    /// </summary>
    public class SinaStockSpider : HAPSpiderClient, IStockerService
    {
        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetStocks()
        {
            return Enumerable.Range(0, 10).Select(index => new Stock());
        }
    }
}
