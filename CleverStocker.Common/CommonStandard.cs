using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        /// Gets 交易市场代码和名称字典
        /// </summary>
        public static ReadOnlyDictionary<Markets, (string Code, string Name)> MarketDictionary { get; } =
            new ReadOnlyDictionary<Markets, (string Code, string Name)>(
                new Dictionary<Markets, (string Code, string Name)>()
                {
                    { Markets.ShangHai, ("sh", "上交所") },
                    { Markets.ShenZhen, ("sz", "深交所") },
                });
    }
}
