using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleverStocker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleverStocker.Model;
using static CleverStocker.Common.CommonStandard;
using System.Diagnostics;

namespace CleverStocker.Utils.Tests
{
    [TestClass()]
    public class ExpressionCloneHelperTests
    {
        [TestMethod()]
        public void CloneTest()
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

            // 原生克隆函数
            Quota Clone(Quota q)
                => new Quota()
                {
                    Amount = q.Amount,
                    AuctionPrice = q.AuctionPrice,
                    BiddingPrice = q.BiddingPrice,
                    BuyPrice1 = q.BuyPrice1,
                    BuyPrice2 = q.BuyPrice2,
                    BuyPrice3 = q.BuyPrice3,
                    BuyPrice4 = q.BuyPrice4,
                    BuyPrice5 = q.BuyPrice5,
                    BuyStrand1 = q.BuyStrand1,
                    BuyStrand2 = q.BuyStrand2,
                    BuyStrand3 = q.BuyStrand3,
                    BuyStrand4 = q.BuyStrand4,
                    BuyStrand5 = q.BuyStrand5,
                    ClosingPriceYesterday = q.ClosingPriceYesterday,
                    Code = q.Code,
                    Count = q.Count,
                    CurrentPrice = q.CurrentPrice,
                    DayHighPrice = q.DayHighPrice,
                    DayLowPrice = q.DayLowPrice,
                    Market = q.Market,
                    Name = q.Name,
                    OpeningPriceToday = q.OpeningPriceToday,
                    SellPrice1 = q.SellPrice1,
                    SellPrice2 = q.SellPrice2,
                    SellPrice3 = q.SellPrice3,
                    SellPrice4 = q.SellPrice4,
                    SellPrice5 = q.SellPrice5,
                    SellStrand1 = q.SellStrand1,
                    SellStrand2 = q.SellStrand2,
                    SellStrand3 = q.SellStrand3,
                    SellStrand4 = q.SellStrand4,
                    SellStrand5 = q.SellStrand5,
                    UpdateTime = q.UpdateTime,
                };

            Stopwatch nativeWatch = new Stopwatch();
            nativeWatch.Start();
            for (int index = 0; index < 10000; index++)
            {
                _ = Clone(quota);
            }
            nativeWatch.Stop();
            Console.WriteLine($"原生方法耗时：{nativeWatch.ElapsedMilliseconds} ms");

            Stopwatch expresssionWatch = new Stopwatch();
            expresssionWatch.Start();
            for (int index = 0; index < 10000; index++)
            {
                _ = ExpressionCloneHelper<Quota, Quota>.Clone(quota);
            }
            expresssionWatch.Stop();
            Console.WriteLine($"表达式树克隆耗时：{expresssionWatch.ElapsedMilliseconds} ms");
        }
    }
}