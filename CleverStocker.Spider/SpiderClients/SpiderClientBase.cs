using System.Net;
using System.Net.Http;
using HtmlAgilityPack;

namespace CleverStocker.Spider.SpiderClients
{
    /// <summary>
    /// 爬虫客户端基类
    /// </summary>
    public abstract class SpiderClientBase : ISpiderClient
    {
        /// <summary>
        /// 锁芯
        /// </summary>
        private readonly object lockSeed = new object();

        /// <summary>
        /// WebClient
        /// </summary>
        private WebClient webClient = null;

        /// <summary>
        /// HttpClient
        /// </summary>
        private HttpClient httpClient = null;

        /// <summary>
        /// Gets WebClient
        /// </summary>
        public WebClient WebClient
        {
            get
            {
                if (this.webClient == null)
                {
                    lock (this.lockSeed)
                    {
                        if (this.webClient == null)
                        {
                            this.webClient = this.CreateWebClient();
                        }
                    }
                }

                return this.webClient;
            }
        }

        /// <summary>
        /// Gets HttpClient
        /// </summary>
        public HttpClient HttpClient
        {
            get
            {
                if (this.httpClient == null)
                {
                    lock (this.lockSeed)
                    {
                        if (this.httpClient == null)
                        {
                            this.httpClient = this.CreateHttpClient();
                        }
                    }
                }

                return this.httpClient;
            }
        }

        /// <summary>
        /// 创建 WebClient
        /// </summary>
        /// <returns></returns>
        protected virtual WebClient CreateWebClient()
            => new WebClient() { };

        /// <summary>
        /// 创建 HttpClient
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient CreateHttpClient()
            => new HttpClient() { };

        /// <summary>
        /// 获取 HTML 文档
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public virtual HtmlDocument GetHtmlDocument(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            return document;
        }
    }
}
