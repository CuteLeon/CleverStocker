using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleverStocker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleverStocker.Model;
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

            // TODO: 需要验证数据并测试性能
        }
    }
}