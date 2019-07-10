using System;
using System.Diagnostics;
using CleverStocker.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Utils.Tests
{
    [TestClass()]
    public class SerializerHelperTests
    {
        [TestMethod()]
        public void SerializerHelperTest()
        {
            Quota quota = new Quota()
            {
                Amount = 100_0000,
                AuctionPrice = 110,
                BiddingPrice = 90,
                BuyPrice1 = 91,
                BuyPrice2 = 92,
                BuyPrice3 = 93,
                BuyPrice4 = 94,
                BuyPrice5 = 95,
                BuyStrand1 = 1000,
                BuyStrand2 = 2000,
                BuyStrand3 = 3000,
                BuyStrand4 = 4000,
                BuyStrand5 = 5000,
                ClosingPriceYesterday = 95,
                Code = "000001",
                Count = 10000,
                CurrentPrice = 100,
                DayHighPrice = 110,
                DayLowPrice = 90,
                Market = Markets.ShangHai,
                Name = "上证指数",
                OpeningPriceToday = 105,
                SellPrice1 = 115,
                SellPrice2 = 114,
                SellPrice3 = 113,
                SellPrice4 = 112,
                SellPrice5 = 111,
                SellStrand1 = 1000,
                SellStrand2 = 2000,
                SellStrand3 = 3000,
                SellStrand4 = 4000,
                SellStrand5 = 5000,
                Stock = new Stock("000001", Markets.ShangHai, "上证指数"),
                UpdateTime = new DateTime(2020, 12, 31, 12, 30, 15),
            };

            // 将导致循环引用问题
            // quota.Stock.Quotas.Add(quota);

            var content = SerializerHelper.Serialize(quota);
            Assert.IsFalse(string.IsNullOrWhiteSpace(content));

            var newQuota = SerializerHelper.Deserialize<Quota>(content);
            Assert.AreEqual(quota.Amount, newQuota.Amount);
            Assert.AreEqual(quota.AuctionPrice, newQuota.AuctionPrice);
            Assert.AreEqual(quota.BiddingPrice, newQuota.BiddingPrice);
            Assert.AreEqual(quota.BuyPrice1, newQuota.BuyPrice1);
            Assert.AreEqual(quota.BuyPrice2, newQuota.BuyPrice2);
            Assert.AreEqual(quota.BuyPrice3, newQuota.BuyPrice3);
            Assert.AreEqual(quota.BuyPrice4, newQuota.BuyPrice4);
            Assert.AreEqual(quota.BuyPrice5, newQuota.BuyPrice5);
            Assert.AreEqual(quota.BuyStrand1, newQuota.BuyStrand1);
            Assert.AreEqual(quota.BuyStrand2, newQuota.BuyStrand2);
            Assert.AreEqual(quota.BuyStrand3, newQuota.BuyStrand3);
            Assert.AreEqual(quota.BuyStrand4, newQuota.BuyStrand4);
            Assert.AreEqual(quota.BuyStrand5, newQuota.BuyStrand5);
            Assert.AreEqual(quota.ClosingPriceYesterday, newQuota.ClosingPriceYesterday);
            Assert.AreEqual(quota.Code, newQuota.Code);
            Assert.AreEqual(quota.Count, newQuota.Count);
            Assert.AreEqual(quota.CurrentPrice, newQuota.CurrentPrice);
            Assert.AreEqual(quota.DayHighPrice, newQuota.DayHighPrice);
            Assert.AreEqual(quota.DayLowPrice, newQuota.DayLowPrice);
            Assert.AreEqual(quota.Market, newQuota.Market);
            Assert.AreEqual(quota.Name, newQuota.Name);
            Assert.AreEqual(quota.OpeningPriceToday, newQuota.OpeningPriceToday);
            Assert.AreEqual(quota.SellPrice1, newQuota.SellPrice1);
            Assert.AreEqual(quota.SellPrice2, newQuota.SellPrice2);
            Assert.AreEqual(quota.SellPrice3, newQuota.SellPrice3);
            Assert.AreEqual(quota.SellPrice4, newQuota.SellPrice4);
            Assert.AreEqual(quota.SellPrice5, newQuota.SellPrice5);
            Assert.AreEqual(quota.SellStrand1, newQuota.SellStrand1);
            Assert.AreEqual(quota.SellStrand2, newQuota.SellStrand2);
            Assert.AreEqual(quota.SellStrand3, newQuota.SellStrand3);
            Assert.AreEqual(quota.SellStrand4, newQuota.SellStrand4);
            Assert.AreEqual(quota.SellStrand5, newQuota.SellStrand5);
            Assert.AreEqual(quota.UpdateTime, newQuota.UpdateTime);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int index = 0; index < 10000; index++)
            {
                _ = SerializerHelper.Serialize(quota);
            }
            stopwatch.Stop();
            Console.WriteLine($"序列化 10000 次耗时：{stopwatch.ElapsedMilliseconds} ms");
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000);

            stopwatch.Restart();
            for (int index = 0; index < 10000; index++)
            {
                _ = SerializerHelper.Deserialize<Quota>(content);
            }
            stopwatch.Stop();
            Console.WriteLine($"反序列化 10000 次耗时：{stopwatch.ElapsedMilliseconds} ms");
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000);
        }
    }
}