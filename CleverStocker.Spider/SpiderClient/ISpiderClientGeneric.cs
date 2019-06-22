using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CleverStocker.Spider.SpiderClient
{
    /// <summary>
    /// 泛型爬虫接口
    /// </summary>
    /// <typeparam name="TDocument">文档类型</typeparam>
    public interface ISpiderClientGeneric<TDocument>
    {
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        TDocument Load(string url);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        TDocument Load(string url, string method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        TDocument Load(Uri uri);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        TDocument Load(Uri uri, string method);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        TDocument Load(string url, string method, WebProxy proxy, NetworkCredential credentials);

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="method"></param>
        /// <param name="proxy"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        TDocument Load(Uri uri, string method, WebProxy proxy, NetworkCredential credentials);
    }
}
