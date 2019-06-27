using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.Model.Comparers.Tests
{
    [TestClass()]
    public class QuotaComparerTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            QuotaComparer comparer = new QuotaComparer();
            Stock stock = new Stock();
            Quota quota1 = new Quota();
            Quota quota2 = new Quota();

            Assert.IsFalse(comparer.Equals(quota1, null));
            Assert.IsFalse(comparer.Equals(null, quota1));
            Assert.IsTrue(comparer.Equals(quota1, quota1));
            Assert.IsTrue(comparer.Equals(quota1, quota2));

            quota1.Stock = stock;
            Assert.IsFalse(comparer.Equals(quota1, quota2));

            quota2.Stock = stock;
            Assert.IsTrue(comparer.Equals(quota1, quota2));

            quota1.UpdateTime = DateTime.Now;
            Assert.IsFalse(comparer.Equals(quota1, quota2));
        }
    }
}