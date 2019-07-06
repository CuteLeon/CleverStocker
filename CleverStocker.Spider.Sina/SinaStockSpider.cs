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
        #region 正则表达式

        /// <summary>
        /// Gets 行情正则表达式
        /// </summary>
        public static Regex QuotaRegex { get; } = new Regex(
            $@"var\s.*\=""(?<Name>.*?),{string.Join(",", Enumerable.Range(1, 7).Select(index => $@"(?<Price{index}>[\d\.]+?)"))},(?<Amount1>\d+?),(?<Amount2>[\d\.]+?),{string.Join(",", Enumerable.Range(1, 10).Select(index => $@"(?<Strand{index}>\d+?),(?<Quote{index}>[\d\.]+?)"))},(?<DateTime>\d{{4}}-\d{{2}}-\d{{2}},\d{{2}}:\d{{2}}:\d{{2}}),00,?"";",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 大盘指数正则表达式
        /// </summary>
        public static Regex MarketQuotaRegex { get; } = new Regex(
            @"var\s.*\=""(?<Name>.*?),(?<Price>[\d\.]+?),(?<Range>-?[\d\.]+?),(?<Rate>-?[\d\.]+?),(?<Count>\d+?),(?<Amount>\d+?)"";",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 公司信息正则表达式
        /// </summary>
        public static Regex CompanyRegex { get; } = new Regex(
            @"var\s.*?\""rank\""\:(?<Rank>\d+?),\""vote\""\:(?<Vote>\d+?),.*?\""name\""\:\""(?<Name>.*?)\"",\""position\""\:\""(?<Position>.*?)\"",\""summary\""\:\""(?<Summary>.*?)\"",\""corp_brief\""\:\""(?<CorpBrief>.*?)\"",\""industry\""\:\""(?<Industry>.*?)\"",.*?\""status\"":\""(?<Status>.*?)\"",.*",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets json 数组正则表达式
        /// </summary>
        public static Regex JsonArrayRegex { get; } = new Regex(
            @".*?regexflag\(\[(?<JsonArray>.*?)\]\);",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 最近行情正则表达式
        /// </summary>
        public static Regex RecentQuotaRegex { get; } = new Regex(
            @"\{\""day\"":\""(?<DateTime>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2})\"",\""open\"":\""(?<Openning>[\d\.]+?)\"",\""high\"":\""(?<Highest>[\d\.]+?)\"",\""low\"":\""(?<Lowest>[\d\.]+?)\"",\""close\"":\""(?<Closing>[\d\.]+?)\"",\""volume\"":\""(?<Volume>\d+?)\""\}",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 所有\大宗交易列表正则表达式
        /// </summary>
        public static Regex AllBlockTradeRegex { get; } = new Regex(
            @"_list\[\d+\]\s=\snew\sArray\(\'(?<DateTime>\d{2}:\d{2}:\d{2})\',\s\'(?<Count>\d+?)\',\s\'(?<Price>[\d\.]+?)\',\s\'(?<Type>UP|DOWN)\'\);",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 分时交易列表正则表达式
        /// </summary>
        public static Regex TradeByMinuteRegex { get; } = new Regex(
            @"\[\'(?<DateTime>\d{2}:\d{2}:\d{2})\',\s'(?<Price>[\d\.]+?)\',\s\'(?<Count>\d+?)\'\]",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Gets 分价交易列表正则表达式
        /// </summary>
        public static Regex TradeByPriceRegex { get; } = new Regex(
            @"_list\[\d+\]\s=\snew\sArray\(\'(?<Price>[\d\.]+?)\',\s\'(?<Count>\d+?)\',\s\'(?<Rate>[\d\.]+?)%\'\);",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
        #endregion

        #region 请求路径

        /// <summary>
        /// 图表请求路径集合
        /// </summary>
        private static Dictionary<Charts, string> chartsRequestAddresses = new Dictionary<Charts, string>()
        {
            { Charts.Minute, @"http://image.sinajs.cn/newchart/min/n/{0}.gif" },
            { Charts.DailyCandlestick, @"http://image.sinajs.cn/newchart/daily/n/{0}.gif" },
            { Charts.WeeklyCandlestick, @"http://image.sinajs.cn/newchart/weekly/n/{0}.gif" },
            { Charts.MonthlyCandlestick, @"http://image.sinajs.cn/newchart/monthly/n/{0}.gif" },
        };

        /// <summary>
        /// 交易列表请求路径集合
        /// </summary>
        private static Dictionary<TradeListTypes, string> tradeListRequestAddresses = new Dictionary<TradeListTypes, string>()
        {
            { TradeListTypes.All, @"https://vip.stock.finance.sina.com.cn/quotes_service/view/CN_TransListV2.php?symbol={0}&num={1}" },
            { TradeListTypes.Block, @"https://vip.stock.finance.sina.com.cn/quotes_service/view/CN_BillList.php?sort=ticktime&symbol={0}&num={1}" },
            { TradeListTypes.ByPrice, @"https://vip.stock.finance.sina.com.cn/quotes_service/view/cn_price_list.php?symbol={0}&num={1}" },
            { TradeListTypes.ByMinute, @"https://vip.stock.finance.sina.com.cn/quotes_service/view/vML_DataList.php?asc=j&symbol={0}&num={1}" },
        };
        #endregion

        #region 行情

        /// <summary>
        /// 获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        /// <remarks>Sina 接口约每三秒更新一次</remarks>
        public (Stock stock, Quota quota) GetStockQuota(string code, Markets market)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (string.IsNullOrEmpty(marketCode) ||
               string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            try
            {
                string request = $@"http://hq.sinajs.cn/list={marketCode}{code}";
                var result = this.WebClient.DownloadString(request);
                if (string.IsNullOrEmpty(result))
                {
                    return default;
                }

                var match = QuotaRegex.Match(result);
                if (!match.Success)
                {
                    return (default, default);
                }

                Stock stock = new Stock(code, market);
                Quota quota = ConvertToQuota(match);
                stock.Name = quota.Name;
                quota.Code = code;
                quota.Market = market;

                return (stock, quota);
            }
            catch (Exception ex)
            {
                LogHelper<SinaStockSpider>.ErrorException(ex, $"获取股票行情失败：");
                throw;
            }
        }

        /// <summary>
        /// 正则匹配转换为行情
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        /// <remarks>如果场景需要，可以将此转换方法重构为适配器模式</remarks>
        public static Quota ConvertToQuota(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            Quota quota = new Quota();
            quota.Name = match.TryGetValue("Name", out string value) ? value : string.Empty;
            quota.OpeningPriceToday = match.TryGetValue("Price1", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.OpeningPriceToday = match.TryGetValue("Price1", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.ClosingPriceYesterday = match.TryGetValue("Price2", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.CurrentPrice = match.TryGetValue("Price3", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.DayHighPrice = match.TryGetValue("Price4", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.DayLowPrice = match.TryGetValue("Price5", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.BiddingPrice = match.TryGetValue("Price6", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.AuctionPrice = match.TryGetValue("Price7", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.Count = match.TryGetValue("Amount1", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.Amount = match.TryGetValue("Amount2", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;

            quota.BuyStrand1 = match.TryGetValue("Strand1", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.BuyPrice1 = match.TryGetValue("Quote1", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand2 = match.TryGetValue("Strand2", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.BuyPrice2 = match.TryGetValue("Quote2", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand3 = match.TryGetValue("Strand3", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.BuyPrice3 = match.TryGetValue("Quote3", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand4 = match.TryGetValue("Strand4", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.BuyPrice4 = match.TryGetValue("Quote4", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.BuyStrand5 = match.TryGetValue("Strand5", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.BuyPrice5 = match.TryGetValue("Quote5", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;

            quota.SellStrand1 = match.TryGetValue("Strand6", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.SellPrice1 = match.TryGetValue("Quote6", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand2 = match.TryGetValue("Strand7", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.SellPrice2 = match.TryGetValue("Quote7", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand3 = match.TryGetValue("Strand8", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.SellPrice3 = match.TryGetValue("Quote8", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand4 = match.TryGetValue("Strand9", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.SellPrice4 = match.TryGetValue("Quote9", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.SellStrand5 = match.TryGetValue("Strand10", out value) ? ConverterHelper.StringToLong(value) : -1L;
            quota.SellPrice5 = match.TryGetValue("Quote10", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            quota.UpdateTime = match.TryGetValue("DateTime", out value) ? ConverterHelper.StringToDateTime(value) : DateTime.Now;

            return quota;
        }

        /// <summary>
        /// 异步获取股票行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock stock, Quota quota)> GetStockQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockQuota(code, market));
        #endregion

        #region 大盘指数

        /// <summary>
        /// 获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public (Stock stock, MarketQuota marketQuota) GetStockMarketQuota(string code, Markets market)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (string.IsNullOrEmpty(marketCode) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            try
            {
                string request = $@"http://hq.sinajs.cn/list=s_{marketCode}{code}";
                var result = this.WebClient.DownloadString(request);
                if (string.IsNullOrEmpty(result))
                {
                    return default;
                }

                var match = MarketQuotaRegex.Match(result);
                if (!match.Success)
                {
                    return (default, default);
                }

                Stock stock = new Stock(code, market);
                MarketQuota marketQuota = ConvertToMarketQuota(match);
                stock.Name = marketQuota.Name;
                marketQuota.Code = code;
                marketQuota.Market = market;

                return (stock, marketQuota);
            }
            catch (Exception ex)
            {
                LogHelper<SinaStockSpider>.ErrorException(ex, "获取大盘指数失败：");
                throw;
            }
        }

        /// <summary>
        /// 正则匹配转换为大盘指数
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        /// <remarks>如果场景需要，可以将此转换方法重构为适配器模式</remarks>
        public static MarketQuota ConvertToMarketQuota(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            MarketQuota marketQuota = new MarketQuota();
            marketQuota.Name = match.TryGetValue("Name", out string value) ? value : string.Empty;
            marketQuota.CurrentPrice = match.TryGetValue("Price", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            marketQuota.FluctuatingRange = match.TryGetValue("Range", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            marketQuota.FluctuatingRate = match.TryGetValue("Rate", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            marketQuota.Count = match.TryGetValue("Count", out value) ? ConverterHelper.StringToLong(value) : -1L;
            marketQuota.Amount = match.TryGetValue("Amount", out value) ? ConverterHelper.StringToLong(value) : -1L;
            marketQuota.UpdateTime = DateTime.Now;

            return marketQuota;
        }

        /// <summary>
        /// 异步获取股票大盘指数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<(Stock stock, MarketQuota marketQuota)> GetStockMarketQuotaAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetStockMarketQuota(code, market));
        #endregion

        #region 图表

        /// <summary>
        /// 获取图表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="chart"></param>
        /// <returns></returns>
        public Image GetChart(string code, Markets market, Charts chart)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (!chartsRequestAddresses.TryGetValue(chart, out string request) ||
                string.IsNullOrEmpty(marketCode) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            request = string.Format(request, $"{marketCode}{code}");
            var result = this.HttpClient.GetStreamAsync(request).Result;
            if (result == null)
            {
                return default;
            }

            Image image = Image.FromStream(result);

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
        #endregion

        #region 公司信息

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public Company GetCompany(string code, Markets market)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (string.IsNullOrEmpty(marketCode) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            try
            {
                string request = $@"https://finance.sina.com.cn/otc/activity/{marketCode}{code}_info.js";
                var result = this.WebClient.DownloadString(request);
                if (string.IsNullOrEmpty(result))
                {
                    return default;
                }

                var match = CompanyRegex.Match(result);
                if (!match.Success)
                {
                    return default;
                }

                Company company = ConvertToCompany(match);
                company.Code = code;
                company.Market = market;

                return company;
            }
            catch (Exception ex)
            {
                LogHelper<SinaStockSpider>.ErrorException(ex, "获取公司信息失败：");
                throw;
            }
        }

        /// <summary>
        /// 转换正则匹配结果为公司信息
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static Company ConvertToCompany(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            Company company = new Company();
            company.Name = match.TryGetValue("Name", out string value) ? Regex.Unescape(value) : string.Empty;
            company.Position = match.TryGetValue("Position", out value) ? Regex.Unescape(value) : string.Empty;
            company.Industry = match.TryGetValue("Industry", out value) ? Regex.Unescape(value) : string.Empty;
            company.Rank = match.TryGetValue("Rank", out value) ? Regex.Unescape(value) : string.Empty;
            company.Status = match.TryGetValue("Status", out value) ? Regex.Unescape(value) : string.Empty;
            company.Summary = match.TryGetValue("Summary", out value) ? Regex.Unescape(value) : string.Empty;
            company.Brief = match.TryGetValue("CorpBrief", out value) ? Regex.Unescape(value) : string.Empty;
            company.Vote = match.TryGetValue("Vote", out value) ? ConverterHelper.StringToInt(value) : 0;

            return company;
        }

        /// <summary>
        /// 异步获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <returns></returns>
        public async Task<Company> GetCompanyAsync(string code, Markets market)
            => await Task.Factory.StartNew(() => this.GetCompany(code, market));
        #endregion

        #region 最近行情

        /// <summary>
        /// 获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<RecentQuota> GetRecentQuotas(string code, Markets market, TimeScales timeScale, int count)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (string.IsNullOrEmpty(marketCode) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            int scale = timeScale.GetAmbientValue<int>();
            string request = $@"https://quotes.sina.cn/cn/api/jsonp_v2.php/regexflag/CN_MarketDataService.getKLineData?symbol={marketCode}{code}&scale={scale}&ma=no&datalen={count}";

            var result = this.WebClient.DownloadString(request);
            if (string.IsNullOrEmpty(result))
            {
                return Enumerable.Empty<RecentQuota>().ToList();
            }

            var arrayMatch = JsonArrayRegex.Match(result);
            if (arrayMatch.Success &&
                arrayMatch.Groups["JsonArray"].Success)
            {
                result = arrayMatch.Groups["JsonArray"].Value;
            }
            else
            {
                return Enumerable.Empty<RecentQuota>().ToList();
            }

            List<RecentQuota> recentQuotas = new List<RecentQuota>(count);
            recentQuotas.AddRange(
                RecentQuotaRegex.Matches(result)
                    .Cast<Match>()
                    .Select(match => ConvertToRecentQuota(match))
                    .Where(quota => quota != null));

            recentQuotas.ForEach(quota =>
            {
                quota.Code = code;
                quota.Market = market;
            });

            return recentQuotas;
        }

        /// <summary>
        /// 转换正则匹配结果为最近行情
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public static RecentQuota ConvertToRecentQuota(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            RecentQuota recentQuota = new RecentQuota();
            recentQuota.UpdateTime = match.TryGetValue("DateTime", out string value) ? ConverterHelper.StringToDateTime(value) : DateTime.Now;
            recentQuota.OpenningPrice = match.TryGetValue("Openning", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            recentQuota.HighestPrice = match.TryGetValue("Highest", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            recentQuota.LowestPrice = match.TryGetValue("Lowest", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            recentQuota.ClosingPrice = match.TryGetValue("Closing", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            recentQuota.Volume = match.TryGetValue("Volume", out value) ? ConverterHelper.StringToLong(value) : -1L;

            return recentQuota;
        }

        /// <summary>
        /// 异步获取最近行情
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="timeScale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<RecentQuota>> GetRecentQuotasAsync(string code, Markets market, TimeScales timeScale, int count)
            => await Task.Factory.StartNew(() => this.GetRecentQuotas(code, market, timeScale, count));
        #endregion

        #region 最近交易

        /// <summary>
        /// 获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="market"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Trade> GetRecentTrades(string code, Markets market, TradeListTypes tradeListType, int count)
        {
            string marketCode = SinaSpiderHelper.GetMarketCode(market);
            if (!tradeListRequestAddresses.TryGetValue(tradeListType, out string request) ||
                string.IsNullOrEmpty(marketCode) ||
                string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException();
            }

            request = string.Format(request, $"{marketCode}{code}", count);
            var result = this.WebClient.DownloadString(request);
            if (string.IsNullOrEmpty(result))
            {
                return Enumerable.Empty<Trade>().ToList();
            }

            var (regex, convertor) = GetTradeListRegexConvertor(tradeListType);
            if (regex == null ||
                convertor == null)
            {
                return Enumerable.Empty<Trade>().ToList();
            }

            List<Trade> trades = new List<Trade>(count);

            trades.AddRange(
                regex.Matches(result).Cast<Match>()
                .Select(convertor)
                .Where(trade => trade != null));

            trades.ForEach(trade =>
            {
                trade.Code = code;
                trade.Market = market;
            });

            return trades;
        }

        /// <summary>
        /// 获取交易列表正则表达式
        /// </summary>
        /// <param name="tradeListType"></param>
        /// <returns></returns>
        public static (Regex, Func<Match, Trade>) GetTradeListRegexConvertor(TradeListTypes tradeListType)
        {
            switch (tradeListType)
            {
                case TradeListTypes.All:
                case TradeListTypes.Block:
                    {
                        return (AllBlockTradeRegex, ConvertToTradeAllBlock);
                    }

                case TradeListTypes.ByMinute:
                    {
                        return (TradeByMinuteRegex, ConvertToTradeMinute);
                    }

                case TradeListTypes.ByPrice:
                    {
                        return (TradeByPriceRegex, ConvertToTradePrice);
                    }

                default:
                    {
                        return default;
                    }
            }
        }

        /// <summary>
        /// 转换匹配结果为交易
        /// </summary>
        /// <param name="match"></param>
        private static Trade ConvertToTradeAllBlock(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            Trade trade = new Trade();
            trade.UpdateTime = match.TryGetValue("DateTime", out string value) ? ConverterHelper.StringToDateTime(value) : DateTime.Now;
            trade.Price = match.TryGetValue("Price", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            trade.Count = match.TryGetValue("Count", out value) ? ConverterHelper.StringToLong(value) : -1L;
            trade.TradeType = match.TryGetValue("Type", out value) && string.Equals(value, "UP", StringComparison.OrdinalIgnoreCase) ? TradeTypes.Buy : TradeTypes.Sell;

            return trade;
        }

        /// <summary>
        /// 转换匹配结果为交易
        /// </summary>
        /// <param name="match"></param>
        private static Trade ConvertToTradeMinute(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            Trade trade = new Trade();
            trade.UpdateTime = match.TryGetValue("DateTime", out string value) ? ConverterHelper.StringToDateTime(value) : DateTime.Now;
            trade.Price = match.TryGetValue("Price", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            trade.Count = match.TryGetValue("Count", out value) ? ConverterHelper.StringToLong(value) : -1L;

            return trade;
        }

        /// <summary>
        /// 转换匹配结果为交易
        /// </summary>
        /// <param name="match"></param>
        private static Trade ConvertToTradePrice(Match match)
        {
            if (!match.Success)
            {
                return default;
            }

            Trade trade = new Trade();
            trade.Price = match.TryGetValue("Price", out string value) ? ConverterHelper.StringToDouble(value) : double.NaN;
            trade.Count = match.TryGetValue("Count", out value) ? ConverterHelper.StringToLong(value) : -1L;
            trade.Rate = match.TryGetValue("Rate", out value) ? ConverterHelper.StringToDouble(value) : double.NaN;

            return trade;
        }

        /// <summary>
        /// 异步获取最近交易
        /// </summary>
        /// <param name="code"></param>
        /// <param name="markets"></param>
        /// <param name="tradeListType"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<Trade>> GetRecentTradesAsync(string code, Markets markets, TradeListTypes tradeListType, int count)
            => await Task.Factory.StartNew(() => this.GetRecentTrades(code, markets, tradeListType, count));
        #endregion
    }
}
