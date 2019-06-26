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
            string response = @"var hq_str_sh600086=""东方金钰,4.750,4.860,4.510,4.860,4.480,4.500,4.510,134032650,616704101.000,312445,4.500,306400,4.490,582132,4.480,336400,4.470,313200,4.460,91971,4.510,257500,4.520,206800,4.530,41000,4.540,57900,4.550,2019-06-26,15:00:00,00,"";";
            var match = spider.StockRegex.Match(response);
            Assert.IsTrue(match.Success);
        }
    }
}