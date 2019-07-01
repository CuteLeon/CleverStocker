using System.Collections.Generic;
using CleverStocker.Model;

namespace CleverStocker.Services
{
    /// <summary>
    /// 股票接口
    /// </summary>
    public interface IStockService : IPersistService<Stock>
    {
        /// <summary>
        /// 移除自选股票
        /// </summary>
        /// <param name="stock"></param>
        void RemoveSelfSelectStock(Stock stock);

        /// <summary>
        /// 添加自选股票
        /// </summary>
        /// <param name="stock"></param>
        void AddSelfSelectStock(Stock stock);

        /// <summary>
        /// 按值搜索股票
        /// </summary>
        /// <param name="isSelfSelect"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        List<Stock> QueryStock(bool isSelfSelect = false, string keyWord = null);
    }
}
