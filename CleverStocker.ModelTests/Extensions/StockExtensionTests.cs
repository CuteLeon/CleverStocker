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
            Stock stock = new Stock("123456", Markets.ShangHai);

            Assert.AreEqual("123456-ShangHai", stock.GetFullCode());
            Assert.AreEqual(("123456", Markets.ShangHai), "123456-ShangHai".GetMarketCode());
        }
    }
}