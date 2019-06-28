using System.ComponentModel;

namespace CleverStocker.Common
{
    /// <summary>
    /// 通用标准
    /// </summary>
    public static class CommonStandard
    {
        /// <summary>
        /// 主题
        /// </summary>
        public enum Themes
        {
            /// <summary>
            /// 经典
            /// </summary>
            Classics = 0,

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
    }
}
