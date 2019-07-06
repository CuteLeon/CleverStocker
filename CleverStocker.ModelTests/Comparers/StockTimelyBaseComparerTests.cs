using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.Model.Comparers.Tests
{
    [TestClass()]
    public class StockTimelyBaseComparerTests
    {
        [TestMethod()]
        public void EqualsTest()
        {
            var comparer = new StockTimelyBaseComparer<Quota>();
            Quota quota1 = new Quota();
            Quota quota2 = new Quota();

            Assert.IsFalse(comparer.Equals(quota1, null));
            Assert.IsFalse(comparer.Equals(null, quota1));
            Assert.IsTrue(comparer.Equals(quota1, quota1));
            Assert.IsTrue(comparer.Equals(quota1, quota2));

            quota1.Code = "1";
            Assert.IsFalse(comparer.Equals(quota1, quota2));

            quota2.Code = "1";
            Assert.IsTrue(comparer.Equals(quota1, quota2));

            quota1.UpdateTime = DateTime.Now;
            Assert.IsFalse(comparer.Equals(quota1, quota2));

            Assert.IsTrue(comparer.Compare(quota1, quota2) == 1);
        }
    }
}