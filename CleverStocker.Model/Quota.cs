﻿using System;
using System.Xml.Serialization;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model
{
    /// <summary>
    /// 行情
    /// </summary>
    public class Quota : StockTimelyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        public Quota()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        public Quota(string code, Markets market)
            : base(code, market)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        public Quota(string code, Markets market, string name)
            : base(code, market, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quota"/> class.
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="market">市场</param>
        /// <param name="name">名称</param>
        /// <param name="updateTime">更新时间</param>
        public Quota(string code, Markets market, string name, DateTime updateTime)
            : base(code, market, name, updateTime)
        {
        }

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [XmlIgnore]
        public virtual Stock Stock { get; set; }

        #region 基本行情

        /// <summary>
        /// Gets or sets 今日开盘价 (单位：元)
        /// </summary>
        public double OpeningPriceToday { get; set; }

        /// <summary>
        /// Gets or sets 昨日收盘价 (单位：元)
        /// </summary>
        public double ClosingPriceYesterday { get; set; }

        /// <summary>
        /// Gets or sets 当前价格 (单位：元)
        /// </summary>
        public double CurrentPrice { get; set; }

        /// <summary>
        /// Gets or sets 今日最高价 (单位：元)
        /// </summary>
        public double DayHighPrice { get; set; }

        /// <summary>
        /// Gets or sets 今日最低价 (单位：元)
        /// </summary>
        public double DayLowPrice { get; set; }

        /// <summary>
        /// Gets or sets 竞买价 (单位：元)
        /// </summary>
        public double BiddingPrice { get; set; }

        /// <summary>
        /// Gets or sets 竞卖价 (单位：元)
        /// </summary>
        public double AuctionPrice { get; set; }

        /// <summary>
        /// Gets or sets 成交股票数量 (单位：股)
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets 成交金额 (单位：元)
        /// </summary>
        public double Amount { get; set; }
        #endregion

        #region 五档盘口

        /// <summary>
        /// Gets or sets 买1股数 (单位：股)
        /// </summary>
        public long BuyStrand1 { get; set; }

        /// <summary>
        /// Gets or sets 买1价格 (单位：元)
        /// </summary>
        public double BuyPrice1 { get; set; }

        /// <summary>
        /// Gets or sets 买2股数 (单位：股)
        /// </summary>
        public long BuyStrand2 { get; set; }

        /// <summary>
        /// Gets or sets 买2价格 (单位：元)
        /// </summary>
        public double BuyPrice2 { get; set; }

        /// <summary>
        /// Gets or sets 买3股数 (单位：股)
        /// </summary>
        public long BuyStrand3 { get; set; }

        /// <summary>
        /// Gets or sets 买3价格 (单位：元)
        /// </summary>
        public double BuyPrice3 { get; set; }

        /// <summary>
        /// Gets or sets 买4股数 (单位：股)
        /// </summary>
        public long BuyStrand4 { get; set; }

        /// <summary>
        /// Gets or sets 买4价格 (单位：元)
        /// </summary>
        public double BuyPrice4 { get; set; }

        /// <summary>
        /// Gets or sets 买5股数 (单位：股)
        /// </summary>
        public long BuyStrand5 { get; set; }

        /// <summary>
        /// Gets or sets 买5价格 (单位：元)
        /// </summary>
        public double BuyPrice5 { get; set; }

        /// <summary>
        /// Gets or sets 卖1股数 (单位：股)
        /// </summary>
        public long SellStrand1 { get; set; }

        /// <summary>
        /// Gets or sets 卖1价格 (单位：元)
        /// </summary>
        public double SellPrice1 { get; set; }

        /// <summary>
        /// Gets or sets 卖2股数 (单位：股)
        /// </summary>
        public long SellStrand2 { get; set; }

        /// <summary>
        /// Gets or sets 卖2价格 (单位：元)
        /// </summary>
        public double SellPrice2 { get; set; }

        /// <summary>
        /// Gets or sets 卖3股数 (单位：股)
        /// </summary>
        public long SellStrand3 { get; set; }

        /// <summary>
        /// Gets or sets 卖3价格 (单位：元)
        /// </summary>
        public double SellPrice3 { get; set; }

        /// <summary>
        /// Gets or sets 卖4股数 (单位：股)
        /// </summary>
        public long SellStrand4 { get; set; }

        /// <summary>
        /// Gets or sets 卖4价格 (单位：元)
        /// </summary>
        public double SellPrice4 { get; set; }

        /// <summary>
        /// Gets or sets 卖5股数 (单位：股)
        /// </summary>
        public long SellStrand5 { get; set; }

        /// <summary>
        /// Gets or sets 卖5价格 (单位：元)
        /// </summary>
        public double SellPrice5 { get; set; }
        #endregion
    }
}
