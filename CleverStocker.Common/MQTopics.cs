namespace CleverStocker.Common
{
    /// <summary>
    /// MQ 主题
    /// </summary>
    public static class MQTopics
    {
        #region 股票主题

        /// <summary>
        /// 股票
        /// </summary>
        public static readonly string TopicStock = "Stock";

        /// <summary>
        /// 当前选中股票变化
        /// </summary>
        public static readonly string TopicCurrentChangeStock = "Stock.Current.Change";

        /// <summary>
        /// 添加股票
        /// </summary>
        public static readonly string TopicStockAdd = $"{TopicStock}.All.Add";

        /// <summary>
        /// 删除股票
        /// </summary>
        public static readonly string TopicStockRemove = $"{TopicStock}.All.Remove";

        /// <summary>
        /// 更新股票
        /// </summary>
        public static readonly string TopicStockUpdate = $"{TopicStock}.All.Update";

        /// <summary>
        /// 添加自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectAdd = $"{TopicStock}.SelfSelect.Add";

        /// <summary>
        /// 删除自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectRemove = $"{TopicStock}.SelfSelect.Remove";

        /// <summary>
        /// 更新自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectUpdate = $"{TopicStock}.SelfSelect.Update";
        #endregion

    }
}
