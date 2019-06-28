using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Spider.Sina
{
    /// <summary>
    /// Sian 爬虫助手
    /// </summary>
    public static class SinaSpiderHelper
    {
        /// <summary>
        /// 获取市场代码
        /// </summary>
        /// <param name="market"></param>
        /// <returns></returns>
        public static string GetMarketCode(Markets market)
        {
            switch (market)
            {
                case Markets.ShangHai:
                    return "sh";
                case Markets.ShenZhen:
                    return "sz";
                case Markets.Unknown:
                default:
                    return string.Empty;
            }
        }
    }
}
