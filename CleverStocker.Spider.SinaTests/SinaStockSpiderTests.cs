using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.Spider.Sina.Tests
{
    [TestClass()]
    public class SinaStockSpiderTests
    {
        [TestMethod()]
        public void GetStockTest()
        {
            SinaStockSpider spider = new SinaStockSpider();
            string response = @"var hq_str_sh600086=""东方金钰,4.380,4.510,4.490,4.570,4.320,4.480,4.490,49796325,220884386.000,210200,4.480,665700,4.470,203900,4.460,346700,4.450,400100,4.440,8700,4.490,48900,4.500,99619,4.510,41400,4.520,67300,4.530,2019-06-27,11:30:00,00"";";
            var match = spider.StockRegex.Match(response);
            Assert.IsTrue(match.Success);
        }
    }
}