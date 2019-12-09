using System.Net;
using System.Net.Http;
using CleverStocker.Spider.SpiderClients;

namespace CleverStocker.Spider
{
    // TODO: [非紧急] 腾讯财经爬虫-实时资金流向 (http://qt.gtimg.cn/q=sz000858)
    // TODO: [非紧急] 网易财经爬虫-历史所有交易日行情 (csv 格式)

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
