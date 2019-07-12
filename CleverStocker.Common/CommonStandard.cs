using System.ComponentModel;

namespace CleverStocker.Common
{
    /// <summary>
    /// 通用标准
    /// </summary>
    public static class CommonStandard
    {
        /// <summary>
        /// 上海交易所代码
        /// </summary>
        public const string ShangHaiMarketCode = "sh";

        /// <summary>
        /// 深交所代码
        /// </summary>
        private const string ShenZhenMarketCode = "sz";

        /// <summary>
        /// 空字符串
        /// </summary>
        private const string EmptyString = "";

        /// <summary>
        /// 港交所代码
        /// </summary>
        private const string HongKongMarketCode = "hk";

        /// <summary>
        /// 主题
        /// </summary>
        public enum Themes
        {
            /// <summary>
            /// 浅色
            /// </summary>
            Light = 1,

            /// <summary>
            /// 蓝色
            /// </summary>
            Blue = 2,

            /// <summary>
            /// 深色
            /// </summary>
            Dark = 3,
        }

        /// <summary>
        /// 交易市场
        /// </summary>
        public enum Markets
        {
            /// <summary>
            /// 未知
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// 上交所
            /// </summary>
            ShangHai = 1,

            /// <summary>
            /// 深交所
            /// </summary>
            ShenZhen = 2,

            /// <summary>
            /// 港交所
            /// </summary>
            /// <remarks>五位代码，无市场编码</remarks>
            HongKong = 3,
        }

        /// <summary>
        /// 时间规模
        /// </summary>
        public enum TimeScales
        {
            /// <summary>
            /// 5 分钟
            /// </summary>
            [AmbientValue(5)]
            Minutes_5 = 0,

            /// <summary>
            /// 10 分钟
            /// </summary>
            [AmbientValue(10)]
            Minutes_10 = 1,

            /// <summary>
            /// 15 分钟
            /// </summary>
            [AmbientValue(15)]
            Minutes_15 = 2,

            /// <summary>
            /// 30 分钟
            /// </summary>
            [AmbientValue(30)]
            Minutes_30 = 3,

            /// <summary>
            /// 60 分钟
            /// </summary>
            [AmbientValue(60)]
            Minutes_60 = 4,
        }

        /// <summary>
        /// 交易列表类型
        /// </summary>
        public enum TradeListTypes
        {
            /// <summary>
            /// 逐笔交易
            /// </summary>
            All = 0,

            /// <summary>
            /// 大单交易
            /// </summary>
            Block = 1,

            /// <summary>
            /// 分时交易
            /// </summary>
            ByMinute = 2,

            /// <summary>
            /// 分价交易
            /// </summary>
            ByPrice = 3,
        }

        /// <summary>
        /// 交易方向
        /// </summary>
        public enum TradeTypes
        {
            /// <summary>
            /// 买入
            /// </summary>
            Buy = 0,

            /// <summary>
            /// 卖出
            /// </summary>
            Sell = 1,
        }

        /// <summary>
        /// 图表
        /// </summary>
        public enum Charts
        {
            /// <summary>
            /// 分时
            /// </summary>
            Minute = 0,

            /// <summary>
            /// 日K
            /// </summary>
            DailyCandlestick = 1,

            /// <summary>
            /// 周K
            /// </summary>
            WeeklyCandlestick = 2,

            /// <summary>
            /// 月K
            /// </summary>
            MonthlyCandlestick = 3,
        }

        /// <summary>
        /// 获取市场代码
        /// </summary>
        /// <param name="market"></param>
        /// <returns></returns>
        /// <remarks>switch 语句会生成分支转跳表，在常量匹配场景下，性能优于 if else if ，同 Dictionary 的 O(1) 时间复杂度</remarks>
        public static string GetMarketCode(Markets market)
        {
            switch (market)
            {
                case Markets.ShangHai:
                    return ShangHaiMarketCode;

                case Markets.ShenZhen:
                    return ShenZhenMarketCode;

                case Markets.HongKong:
                    return HongKongMarketCode;

                case Markets.Unknown:
                default:
                    return EmptyString;
            }
        }

        /// <summary>
        /// 获取市场
        /// </summary>
        /// <param name="marketCode"></param>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        public static Markets GetMarket(string marketCode, string stockCode = EmptyString)
        {
            switch (marketCode)
            {
                case ShangHaiMarketCode:
                    return Markets.ShangHai;

                case ShenZhenMarketCode:
                    return Markets.ShenZhen;

                case HongKongMarketCode:
                case null when stockCode?.Length == 5:
                case EmptyString when stockCode?.Length == 5:
                    return Markets.HongKong;

                default:
                    return Markets.Unknown;
            }
        }
    }
}
