using System;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model.Extensions
{
    /// <summary>
    /// 股票扩展
    /// </summary>
    public static class StockExtension
    {
        /// <summary>
        /// 获取股票完整代码
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        /// <remarks>统一使用 GetFullCode 拼接股票标识信息</remarks>
        public static string GetFullCode(this Stock stock)
             => $"{stock.Code}-{stock.Market.ToString()}-{stock.Name}";

        /// <summary>
        /// 获取股票市场和代码
        /// </summary>
        /// <param name="fullCode"></param>
        /// <returns></returns>
        /// <remarks>统一使用 GetMarketCode 解析股票标识信息</remarks>
        public static (string, Markets, string) GetMarketCode(this string fullCode)
        {
            var values = fullCode.Split(new[] { '-' }, 3);
            if (values.Length == 3)
            {
                return (values[0], Enum.TryParse(values[1], out Markets market) ? market : Markets.Unknown, values[2]);
            }
            else
            {
                return (string.Empty, Markets.Unknown, string.Empty);
            }
        }
    }
}
