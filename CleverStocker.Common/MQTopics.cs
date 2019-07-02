namespace CleverStocker.Common
{
    /// <summary>
    /// MQ 主题
    /// </summary>
    public static class MQTopics
    {
        #region MQ指令

        /// <summary>
        /// MQ 命令退出
        /// </summary>
        public const string TopicMQCommandExit = "MQCommand.Exit";
        #endregion

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
        public static readonly string TopicStockCurrentChange = $"{TopicStock}.Current.Change";

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
        #endregion
    }
}
