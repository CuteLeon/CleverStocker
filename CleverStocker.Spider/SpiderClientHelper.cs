using System.Net;
using System.Net.Http;
using CleverStocker.Spider.SpiderClients;

namespace CleverStocker.Spider
{
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
