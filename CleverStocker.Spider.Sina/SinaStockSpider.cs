using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleverStocker.Common.Extensions;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Spider.SpiderClients;
using CleverStocker.Utils;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Spider.Sina
{
    /// <summary>
    /// 新浪股票爬虫
    /// </summary>
    public class SinaStockSpider : SpiderClientBase, IStockSpiderService
    {
        /// <summary>
        /// Gets 行情正则表达式
        /// </summary>
        public static Regex QuotaRegex { get; } = new Regex(
            $@"var\s.*\=""(?<Name>.*?),{string.Join(",", Enumerable.Range(1, 7).Select(index => $@"(?<Price{index}>[\d\.]+?)"))},(?<Amount1>\d+?),(?<Amount2>[\d\.]+?),{string.Join(",", Enumerable.Range(1, 10).Select(index => $@"(?<Strand{index}>\d+?),(?<Quote{index}>[\d\.]+?)"))},(?<DateTime>\d{{4}}-\d{{2}}-\d{{2}},\d{{2}}:\d{{2}}:\d{{2}}),00"";",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 大盘指数正则表达式
        /// </summary>
        public static Regex MarketQuotaRegex { get; } = new Regex(
            $@"var\s.*\=""(?<Name>.*?),(?<Price>[\d\.]+?),(?<Range>-?[\d\.]+?),(?<Rate>-?[\d\.]+?),(?<Count>\d+?),(?<Amount>\d+?)"";",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// 图表请求路径集合
        /// </summary>
        private static Dictionary<Charts, string> ChartsRequestAddresses = new Dictionary<Charts, string>()
        {
            { Charts.Minute, @"http://image.sinajs.cn/newchart/min/n/{0}.gif" },
            { Charts.DailyCandlestick, @"http://image.sinajs.cn/newchart/daily/n/{0}.gif" },
            { Charts.WeeklyCandlestick, @"http://image.sinajs.cn/newchart/weekly/n/{0}.gif" },
            { Charts.MonthlyCandlestick, @"http://image.sinajs.cn/newchart/monthly/n/{0}.gif" },
        };

        /// <summary>
        /// 获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        /// <remarks>Sina 接口约每三秒更新一次</remarks>
        public (Stock stock, Quota quota) GetStockQuota(string code, Markets market)
        {
            if (!MarketDictionary.TryGetValue(market, out var marketInfo) ||
               string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            string request = $@"http://hq.sinajs.cn/list={marketInfo.Code}{code}";
            var result = this.WebClient.DownloadString(request);

            if (string.IsNullOrEmpty(result))
            {
                return default;
            }

            var match = QuotaRegex.Match(result);
            Stock stock = new Stock(code, market);
            ConvertToQuota(match, ref stock, out Quota quota);

            return (stock, quota);
        }

        /// <summary>
        /// 正则匹配转换为行情
        /// </summary>
        /// <param name="match"></param>
        /// <param name="stock"></param>
        /// <param name="quota"></param>
        /// <remarks>如果场景需要，可以将此转换方法重构为适配器模式</remarks>
        public static void ConvertToQuota(Match match, ref Stock stock, out Quota quota)
        {
            if (!match.Success)
            {
                quota = null;
                return;
            }

            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            if (stock.Quotas == null)
            {
                stock.Quotas = new List<Quota>();
            }

            quota = new Quota(stock);
            stock.Quotas.Add(quota);

            stock.Name = match.TryGetValue("Name", out string value) ? value : string.Empty;
            quota.OpeningPriceToday = match.TryGetValue("Price1", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.OpeningPriceToday = match.TryGetValue("Price1", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.ClosingPriceYesterday = match.TryGetValue("Price2", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.CurrentPrice = match.TryGetValue("Price3", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.DayHighPrice = match.TryGetValue("Price4", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.DayLowPrice = match.TryGetValue("Price5", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.BiddingPrice = match.TryGetValue("Price6", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.AuctionPrice = match.TryGetValue("Price7", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.Count = match.TryGetValue("Amount1", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.Amount = match.TryGetValue("Amount2", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;

            quota.BuyStrand1 = match.TryGetValue("Strand1", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.BuyPrice1 = match.TryGetValue("Quote1", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand2 = match.TryGetValue("Strand2", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.BuyPrice2 = match.TryGetValue("Quote2", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand3 = match.TryGetValue("Strand3", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.BuyPrice3 = match.TryGetValue("Quote3", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand4 = match.TryGetValue("Strand4", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.BuyPrice4 = match.TryGetValue("Quote4", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand5 = match.TryGetValue("Strand5", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.BuyPrice5 = match.TryGetValue("Quote5", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;

            quota.SellStrand1 = match.TryGetValue("Strand6", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.SellPrice1 = match.TryGetValue("Quote6", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand2 = match.TryGetValue("Strand7", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.SellPrice2 = match.TryGetValue("Quote7", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand3 = match.TryGetValue("Strand8", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.SellPrice3 = match.TryGetValue("Quote8", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand4 = match.TryGetValue("Strand9", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.SellPrice4 = match.TryGetValue("Quote9", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand5 = match.TryGetValue("Strand10", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            quota.SellPrice5 = match.TryGetValue("Quote10", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            quota.UpdateTime = match.TryGetValue("DateTime", out value) ? ConvertorHelper.StringToDateTime(value) : DateTime.Now;
            stock.UpdateTime = quota.UpdateTime;
        }

        /// <summary>
        /// 异步获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock stock, Quota quota)> GetStockQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockQuota(code, market));

        /// <summary>
        /// 获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public (Stock stock, MarketQuota marketQuota) GetStockMarketQuota(string code, Markets market)
        {
            if (!MarketDictionary.TryGetValue(market, out var marketInfo) ||
               string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            string request = $@"http://hq.sinajs.cn/list=s_{marketInfo.Code}{code}";
            var result = this.WebClient.DownloadString(request);

            if (string.IsNullOrEmpty(result))
            {
                return default;
            }

            var match = MarketQuotaRegex.Match(result);
            Stock stock = new Stock(code, market);
            ConvertToMarketQuota(match, ref stock, out MarketQuota marketQuota);

            return (stock, marketQuota);
        }

        /// <summary>
        /// 正则匹配转换为大盘指数
        /// </summary>
        /// <param name="match"></param>
        /// <param name="stock"></param>
        /// <param name="marketQuota"></param>
        /// <remarks>如果场景需要，可以将此转换方法重构为适配器模式</remarks>
        public static void ConvertToMarketQuota(Match match, ref Stock stock, out MarketQuota marketQuota)
        {
            if (!match.Success)
            {
                marketQuota = null;
                return;
            }

            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            if (stock.Quotas == null)
            {
                stock.Quotas = new List<Quota>();
            }

            if (stock.MarketQuotas == null)
            {
                stock.MarketQuotas = new List<MarketQuota>();
            }

            marketQuota = new MarketQuota(stock);
            stock.MarketQuotas.Add(marketQuota);

            stock.Name = match.TryGetValue("Name", out string value) ? value : string.Empty;
            marketQuota.CurrentPrice = match.TryGetValue("Price", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            marketQuota.FluctuatingRange = match.TryGetValue("Range", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            marketQuota.FluctuatingRate = match.TryGetValue("Rate", out value) ? ConvertorHelper.StringToDouble(value) : double.NaN;
            marketQuota.Count = match.TryGetValue("Count", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;
            marketQuota.Amount = match.TryGetValue("Amount", out value) ? ConvertorHelper.StringToLong(value) : long.MinValue;

            marketQuota.UpdateTime = DateTime.Now;
            stock.UpdateTime = marketQuota.UpdateTime;
        }

        /// <summary>
        /// 异步获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock stock, MarketQuota marketQuota)> GetStockMarketQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockMarketQuota(code, market));

        /// <summary>
        /// 获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        public Image GetChart(string code, Markets market, Charts chart)
        {
            if (!MarketDictionary.TryGetValue(market, out var marketInfo) ||
                !ChartsRequestAddresses.TryGetValue(chart, out string request) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            request = string.Format(request, $"{marketInfo.Code}{code}");
            var result = this.HttpClient.GetStreamAsync(request).Result;
            if (result == null)
            {
                return default;
            }

            Image image = Bitmap.FromStream(result);
            Stock stock = new Stock(code, market);

            return image;
        }

        /// <summary>
        /// 异步获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        public async Task<Image> GetChartAsync(string code, Markets market, Charts chart)
            => await Task.Factory.StartNew(() => this.GetChart(code, market, chart));
    }
}
