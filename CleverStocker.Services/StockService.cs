using System.Collections.Generic;
using System.Data.Entity;
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

        /// <summary>
        /// 按值搜索股票
        /// </summary>
        /// <param name="isSelfSelect"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public List<Stock> QueryStock(bool isSelfSelect = false, string keyWord = null)
        {
            IQueryable<Stock> stocks = this.Context.Set<Stock>();

            if (isSelfSelect)
            {
                stocks = stocks.Where(stock => stock.IsSelfSelect);
            }

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                string expression = $"%{keyWord}%";
                stocks = stocks.Where(stock =>
                    DbFunctions.Like(stock.Code, expression) ||
                    DbFunctions.Like(stock.Name, expression));
            }

            return stocks.ToList();
        }
    }
}
