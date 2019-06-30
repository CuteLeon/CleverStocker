namespace CleverStocker.Common
{
    /// <summary>
    /// MQ 主题
    /// </summary>
    public static class MQTopics
    {

        #region UI

        /// <summary>
        /// 主题变化了
        /// </summary>
        public const string TopicThemeChanged = "Theme.Changed";
        #endregion

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
        /// 所有股票
        /// </summary>
        public static readonly string TopicStockAll = $"{TopicStock}.All";

        /// <summary>
        /// 添加所有股票
        /// </summary>
        public static readonly string TopicStockAdd = $"{TopicStockAll}.Add";

        /// <summary>
        /// 删除所有股票
        /// </summary>
        public static readonly string TopicStockRemove = $"{TopicStockAll}.Remove";

        /// <summary>
        /// 更新所有股票
        /// </summary>
        public static readonly string TopicStockUpdate = $"{TopicStockAll}.Update";

        /// <summary>
        /// 自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelect = $"{TopicStock}.SelfSelect";

        /// <summary>
        /// 添加自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectAdd = $"{TopicStockSelfSelect}.Add";

        /// <summary>
        /// 删除自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectRemove = $"{TopicStockSelfSelect}.Remove";

        /// <summary>
        /// 更新自选股票
        /// </summary>
        public static readonly string TopicStockSelfSelectUpdate = $"{TopicStockSelfSelect}.Update";
        #endregion

    }
}
