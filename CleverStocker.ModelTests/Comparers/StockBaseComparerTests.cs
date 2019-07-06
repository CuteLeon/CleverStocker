using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Model.Comparers.Tests
{
    [TestClass()]
    public class StockBaseComparerTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var comparer = new StockBaseComparer<Stock>();
            Stock stock1 = new Stock();
            Stock stock2 = new Stock();

            Assert.IsFalse(comparer.Equals(stock1, null));
            Assert.IsFalse(comparer.Equals(null, stock1));
            Assert.IsTrue(comparer.Equals(stock1, stock1));
            Assert.IsTrue(comparer.Equals(stock1, stock2));

            stock1.Code = "0000001";
            Assert.IsFalse(comparer.Equals(stock1, stock2));

            stock2.Code = "0000001";
            Assert.IsTrue(comparer.Equals(stock1, stock2));

            stock1.Market = Markets.ShangHai;
            Assert.IsFalse(comparer.Equals(stock1, stock2));

            Assert.IsTrue(comparer.Compare(stock1, stock2) == 1);
        }
    }
}