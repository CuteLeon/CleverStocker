using System;
using CleverStocker.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Spider.Sina.Tests
{
    [TestClass()]
    public class SinaStockSpiderTests
    {
        [TestMethod()]
        public void GetStockTest()
        {
            string response = @"var hq_str_sh600086=""东方金钰,4.380,4.510,4.490,4.570,4.320,4.480,4.490,49796325,220884386.000,210200,4.480,665700,4.470,203900,4.460,346700,4.450,400100,4.440,8700,4.490,48900,4.500,99619,4.510,41400,4.520,67300,4.530,2019-06-27,11:30:00,00"";";
            var match = SinaStockSpider.QuotaRegex.Match(response);
            Assert.IsTrue(match.Success);

            var stock = new Stock("6000086", Markets.ShangHai);
            SinaStockSpider.ConvertToQuota(match, ref stock, out Quota quota);

            Assert.AreEqual("东方金钰", stock.Name);
            Assert.AreEqual(4.380, quota.OpeningPriceToday);
            Assert.AreEqual(4.510, quota.ClosingPriceYesterday);
            Assert.AreEqual(4.490, quota.CurrentPrice);
            Assert.AreEqual(4.570, quota.DayHighPrice);
            Assert.AreEqual(4.320, quota.DayLowPrice);
            Assert.AreEqual(4.480, quota.BiddingPrice);
            Assert.AreEqual(4.490, quota.AuctionPrice);
            Assert.AreEqual(49796325, quota.Count);
            Assert.AreEqual(220884386.000, quota.Amount);

            Assert.AreEqual(210200, quota.BuyStrand1);
            Assert.AreEqual(665700, quota.BuyStrand2);
            Assert.AreEqual(203900, quota.BuyStrand3);
            Assert.AreEqual(346700, quota.BuyStrand4);
            Assert.AreEqual(400100, quota.BuyStrand5);
            Assert.AreEqual(4.480, quota.BuyPrice1);
            Assert.AreEqual(4.470, quota.BuyPrice2);
            Assert.AreEqual(4.460, quota.BuyPrice3);
            Assert.AreEqual(4.450, quota.BuyPrice4);
            Assert.AreEqual(4.440, quota.BuyPrice5);

            Assert.AreEqual(8700, quota.SellStrand1);
            Assert.AreEqual(48900, quota.SellStrand2);
            Assert.AreEqual(99619, quota.SellStrand3);
            Assert.AreEqual(41400, quota.SellStrand4);
            Assert.AreEqual(67300, quota.SellStrand5);
            Assert.AreEqual(4.490, quota.SellPrice1);
            Assert.AreEqual(4.500, quota.SellPrice2);
            Assert.AreEqual(4.510, quota.SellPrice3);
            Assert.AreEqual(4.520, quota.SellPrice4);
            Assert.AreEqual(4.530, quota.SellPrice5);

            Assert.AreEqual(new DateTime(2019, 6, 27, 11, 30, 00), quota.UpdateTime);
        }

        [TestMethod()]
        public void GetStockMarketQuotaTest()
        {
            string response = @"var hq_str_s_sh600086=""东方金钰,4.450,-0.060,-1.33,807121,35918"";";
            var match = SinaStockSpider.MarketQuotaRegex.Match(response);
            Assert.IsTrue(match.Success);

            var stock = new Stock("6000086", Markets.ShangHai);
            SinaStockSpider.ConvertToMarketQuota(match, ref stock, out MarketQuota marketQuota);

            Assert.AreEqual("东方金钰", stock.Name);
            Assert.AreEqual(4.450, marketQuota.CurrentPrice);
            Assert.AreEqual(-0.06, marketQuota.FluctuatingRange);
            Assert.AreEqual(-1.33, marketQuota.FluctuatingRate);
            Assert.AreEqual(807121, marketQuota.Count);
            Assert.AreEqual(35918, marketQuota.Amount);
            Assert.AreEqual(stock.UpdateTime, marketQuota.UpdateTime);
            Assert.IsTrue(stock.UpdateTime.Subtract(System.DateTime.Now) < TimeSpan.FromSeconds(5));
        }
    }
}