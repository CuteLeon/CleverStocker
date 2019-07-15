using System.Data.Entity;
using CleverStocker.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.DataAccess.Tests
{
    [TestClass()]
    public class DBContextTests
    {
        [TestMethod()]
        public void DBContextTest()
        {
            var mockContext = new Mock<DBContext>();
            var mockSet = new Mock<DbSet<Stock>>();

            mockContext.Setup(context => context.Stocks).Returns(mockSet.Object);

            mockContext.Object.Stocks.Add(new Stock("123456", Markets.ShangHai, "测试股票"));
            mockContext.Object.SaveChanges();

            mockSet.Verify(m => m.Add(It.IsAny<Stock>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}