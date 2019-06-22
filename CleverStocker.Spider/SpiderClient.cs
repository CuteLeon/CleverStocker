using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CleverStocker.Spider
{
    /// <summary>
    /// 爬虫客户端
    /// </summary>
    public class SpiderClient
    {
        /// <summary>
        /// 网络客户端
        /// </summary>
        public HtmlWeb WebClient = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpiderClient"/> class.
        /// </summary>
        public SpiderClient()
        {
            this.WebClient = new HtmlWeb()
            {
            };
        }
    }
}
