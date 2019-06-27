using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.Model.Comparers.Tests
{
    [TestClass()]
    public class MarketQuotaComparerTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            MarketQuotaComparer comparer = new MarketQuotaComparer();
            Stock stock = new Stock();
            MarketQuota marketQuota1 = new MarketQuota();
            MarketQuota marketQuota2 = new MarketQuota();

            Assert.IsFalse(comparer.Equals(marketQuota1, null));
            Assert.IsFalse(comparer.Equals(null, marketQuota1));
            Assert.IsTrue(comparer.Equals(marketQuota1, marketQuota1));
            Assert.IsTrue(comparer.Equals(marketQuota1, marketQuota2));

            marketQuota1.Stock = stock;
            Assert.IsFalse(comparer.Equals(marketQuota1, marketQuota2));

            marketQuota2.Stock = stock;
            Assert.IsTrue(comparer.Equals(marketQuota1, marketQuota2));

            marketQuota1.UpdateTime = DateTime.Now;
            Assert.IsFalse(comparer.Equals(marketQuota1, marketQuota2));

            Assert.IsTrue(comparer.Compare(marketQuota1, marketQuota2) == 1);
        }
    }
}