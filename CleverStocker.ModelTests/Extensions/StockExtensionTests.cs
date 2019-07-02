using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model.Extensions.Tests
{
    [TestClass()]
    public class StockExtensionTests
    {
        [TestMethod()]
        public void GetFullCodeTest()
        {
            Stock stock = new Stock("123456", Markets.ShangHai, "测试股票");

            Assert.AreEqual("123456-ShangHai-测试股票", stock.GetFullCode());
            Assert.AreEqual(("123456", Markets.ShangHai, "测试股票"), "123456-ShangHai-测试股票".GetMarketCode());
        }
    }
}