using System;
using System.Net;

namespace CleverStocker.Spider.SpiderClient
{
    /// <summary>
    /// 爬虫客户端基类
    /// </summary>
    /// <typeparam name="TDocument">文档类型</typeparam>
    public abstract class SpiderClientGenericBase<TDocument> : ISpiderClientGeneric<TDocument>
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public abstract TDocument Load(string url);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public abstract TDocument Load(string url, string method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public abstract TDocument Load(Uri uri);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public abstract TDocument Load(Uri uri, string method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public abstract TDocument Load(string url, string method, WebProxy proxy, NetworkCredential credentials);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public abstract TDocument Load(Uri uri, string method, WebProxy proxy, NetworkCredential credentials);
    }
}
