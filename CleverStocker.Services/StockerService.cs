using System.Collections.Generic;
using CleverStocker.DataAccess;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 服务抽象基类
    /// </summary>
    public class StockerService : ServiceBase<Stock>, IStockerService
    {
        /// <summary>
        /// Gets 数据库交互
        /// </summary>
        protected DBContext DBContext { get; } = new DBContext();

        /// <summary>
        /// 获取股票集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stock> GetStocks()
        {
            return default;
        }

        /// <summary>
        /// 添加股票
        /// </summary>
        /// <param name="stock"></param>
        public void AddStock(Stock stock)
        {
            this.DBContext.Stocks.Add(stock);
            this.DBContext.SaveChanges();
        }
    }
}
