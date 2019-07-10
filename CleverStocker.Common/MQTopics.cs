namespace CleverStocker.Common
{
    /// <summary>
    /// MQ 主题
    /// </summary>
    /// <remarks>使用 switch 匹配主题常量能获得比一组 if else if 更好的性能</remarks>
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
        public const string TopicStock = "Stock";

        /// <summary>
        /// 添加股票
        /// </summary>
        public const string TopicStockAdd = "Stock.Add";

        /// <summary>
        /// 移除股票
        /// </summary>
        public const string TopicStockRemove = "Stock.Remove";

        /// <summary>
        /// 当前选中股票变化
        /// </summary>
        public const string TopicStockCurrentChange = "Stock.Current.Change";

        /// <summary>
        /// 自选股票
        /// </summary>
        public const string TopicStockSelfSelect = "Stock.SelfSelect";

        /// <summary>
        /// 添加自选股票
        /// </summary>
        public const string TopicStockSelfSelectAdd = "Stock.SelfSelect.Add";

        /// <summary>
        /// 删除自选股票
        /// </summary>
        public const string TopicStockSelfSelectRemove = "Stock.SelfSelect.Remove";
        #endregion
    }
}
