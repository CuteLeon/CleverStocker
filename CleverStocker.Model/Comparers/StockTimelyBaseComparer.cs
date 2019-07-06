namespace CleverStocker.Model.Comparers
{
    /// <summary>
    /// 股票时效性基类比较器
    /// </summary>
    /// <typeparam name="TStockTimelyBase">股票时效性基类</typeparam>
    public class StockTimelyBaseComparer<TStockTimelyBase> : StockBaseComparer<TStockTimelyBase>
        where TStockTimelyBase : StockTimelyBase
    {
        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(TStockTimelyBase x, TStockTimelyBase y)
        {
            int result = base.Compare(x, y);
            if (result != 0)
            {
                return result;
            }

            return x?.UpdateTime > y?.UpdateTime ? 1 : -1;
        }

        /// <summary>
        /// 相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool Equals(TStockTimelyBase x, TStockTimelyBase y)
        {
            bool result = base.Equals(x, y);
            if (!result)
            {
                return result;
            }

            return x?.UpdateTime == y?.UpdateTime;
        }
    }
}
