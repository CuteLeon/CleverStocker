using System.Collections.Generic;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Spider.HtmlAgilityPack;

namespace CleverStocker.Spider.XueQiu
{
    /// <summary>
    /// 雪球股票爬虫
    /// </summary>
    public class XueQiuStockSpider : HAPSpiderClient, IStockerService
    {
        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetStocks()
        {
            throw new System.NotImplementedException();
        }
    }
}
