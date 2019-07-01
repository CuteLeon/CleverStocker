using System.Collections.Generic;
using System.Linq;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 股票服务
    /// </summary>
    public class StockService : PersistServiceBase<Stock>, IStockService
    {
        /// <summary>
        /// 获取自选股票
        /// </summary>
        /// <returns></returns>
        public List<Stock> GetSelfSelectStocks()
            => this.Context.Set<Stock>().Where(stock => stock.IsSelfSelect).ToList();

        /// <summary>
        /// 移除自选股票
        /// </summary>
        /// <param name="stock"></param>
        public void RemoveSelfSelectStock(Stock stock)
        {
            if (stock == null)
            {
                return;
            }

            stock.IsSelfSelect = false;
            this.AddOrUpdate(stock);
        }

        /// <summary>
        /// 添加自选股票
        /// </summary>
        /// <param name="stock"></param>
        public void AddSelfSelectStock(Stock stock)
        {
            if (stock == null)
            {
                return;
            }

            stock.IsSelfSelect = true;
            this.AddOrUpdate(stock);
        }
    }
}
