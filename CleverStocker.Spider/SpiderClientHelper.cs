using System.Net;
using System.Net.Http;
using CleverStocker.Spider.SpiderClients;

namespace CleverStocker.Spider
{
    // TODO: 腾讯财经爬虫-实时资金流向 (http://qt.gtimg.cn/q=sz000858)
    // TODO: 网易财经爬虫-历史所有交易日行情 (csv 格式)
    // TODO: 新浪财经爬虫-使用 代码\名称\拼音 搜索股票

    /// <summary>
    /// 爬虫客户端助手
    /// </summary>
    public static class SpiderClientHelper
    {
        /// <summary>
        /// 爬虫客户端
        /// </summary>
        private static readonly SpiderClient Spider = new SpiderClient();

        /// <summary>
        /// Gets webClient
        /// </summary>
        public static WebClient WebClient { get => Spider.WebClient; }

        /// <summary>
        /// Gets httpClient
        /// </summary>
        public static HttpClient HttpClient { get => Spider.HttpClient; }
    }
}
