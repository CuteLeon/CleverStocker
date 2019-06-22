using System;
using System.Net;
using CleverStocker.Spider.SpiderClient;
using HtmlAgilityPack;

namespace CleverStocker.Spider.HtmlAgilityPack
{
    /// <summary>
    /// 爬虫客户端
    /// </summary>
    /// <see cref="https://html-agility-pack.net/online-examples"/>
    public class HAPSpiderClient : SpiderClientGenericBase<HtmlDocument>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HAPSpiderClient"/> class.
        /// </summary>
        public HAPSpiderClient()
        {
            this.WebClient = new HtmlWeb()
            {
                AutoDetectEncoding = true,
            };
        }

        /// <summary>
        /// Gets 网络客户端
        /// </summary>
        public HtmlWeb WebClient { get; } = null;

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override HtmlDocument Load(string url)
            => this.WebClient.Load(url);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public override HtmlDocument Load(string url, string method)
            => this.WebClient.Load(url, method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public override HtmlDocument Load(Uri uri)
            => this.WebClient.Load(uri);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public override HtmlDocument Load(Uri uri, string method)
            => this.WebClient.Load(uri, method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public override HtmlDocument Load(string url, string method, WebProxy proxy, NetworkCredential credentials)
            => this.WebClient.Load(url, method, proxy, credentials);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public override HtmlDocument Load(Uri uri, string method, WebProxy proxy, NetworkCredential credentials)
            => this.WebClient.Load(uri, method, proxy, credentials);
    }
}