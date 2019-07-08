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

        /// <summary>
        /// 获取市场
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Markets GetMarket(string code)
        {
            switch (code)
            {
                case "sh":
                    return Markets.ShangHai;
                case "sz":
                    return Markets.ShenZhen;
                default:
                    return Markets.Unknown;
            }
        }
    }
}
