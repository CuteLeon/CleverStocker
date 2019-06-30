using CleverStocker.Utils;

namespace CleverStocker.Client.Interfaces
{
    /// <summary>
    /// 允许 MQ 发布订阅消息
    /// </summary>
    public interface IMQPubsubable
    {
        /// <summary>
        /// Gets or sets 发布者名称
        /// </summary>
        /// <remarks>应尽早为此属性赋值</remarks>
        string SourceName { get; set; }

        /// <summary>
        /// Gets or sets 订阅者
        /// </summary>
        SubscriberHandler Subscriber { get; set; }

        /// <summary>
        /// MQ 订阅者接收消息
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        void MQSubscriberReceive(string source, string topic, string message);
    }
}
