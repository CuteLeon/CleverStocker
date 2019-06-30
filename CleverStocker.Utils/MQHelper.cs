using System;
using System.Collections.Generic;
using System.Linq;
using ZeroMQ;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 消息队列助手
    /// </summary>
    public static class MQHelper
    {
        #region MQ配置

        /// <summary>
        /// MQ 端口
        /// </summary>
        /// <remarks>
        /// 0-1023: BSD 系统保留端口
        /// 1024-4999: 临时端口
        /// 5000-65535
        /// 魔法数字：
        /// 点亮生日每个数字代表的二进制位，遇到数字重复时进一
        /// </remarks>
        private static readonly int MQPort = 0b_0101_1100_0010;

        /// <summary>
        /// MQ 主机
        /// </summary>
        private static readonly string MQHost = "tcp://127.0.0.1";

        /// <summary>
        /// MQ 地址
        /// </summary>
        internal static readonly string MQAddress = $"{MQHost}:{MQPort}";

        /// <summary>
        /// 消息字段分离器
        /// </summary>
        internal static readonly char[] Separator = new[] { ' ' };
        #endregion

        #region MQ终端

        /// <summary>
        /// 发布者
        /// </summary>
        private static readonly ZSocket PublisherSocket;
        #endregion

        /// <summary>
        /// Initializes static members of the <see cref="MQHelper"/> class.
        /// </summary>
        static MQHelper()
        {
            LogHelper<ZSocket>.Debug($"创建 MQ 消息发布者 ...");

            try
            {
                PublisherSocket = new ZSocket(ZSocketType.PUB);
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"创建 MQ 消息发布者失败：");
                throw;
            }

            LogHelper<ZSocket>.Debug($"创建 MQ 消息发布者成功");
        }

        /// <summary>
        /// 绑定发布者
        /// </summary>
        public static void BindPublisher()
        {
            LogHelper<ZSocket>.Debug($"启动 MQ 消息发布者 ...");

            try
            {
                PublisherSocket.Bind(MQAddress);
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"启动 MQ 消息发布者失败：");
                throw;
            }

            LogHelper<ZSocket>.Debug($"启动 MQ 消息发布者成功：{MQAddress}");
        }

        /// <summary>
        /// 断开发布者
        /// </summary>
        /// <remarks>下次使用发布者需要重新 Bind() ，订阅者不需要任何操作</remarks>
        public static void DisconnectPublisher()
        {
            LogHelper<ZSocket>.Debug($"断开 MQ 消息发布者 ...");

            try
            {
                PublisherSocket?.Disconnect(MQAddress);
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"断开 MQ 消息发布者失败：");
            }

            LogHelper<ZSocket>.Debug($"断开 MQ 消息发布者成功：{MQAddress}");
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topics"></param>
        /// <param name="receiveDelegate">(发布者，主题，消息)</param>
        /// <returns></returns>
        /// <remarks>
        /// source: 1.不应该出现空格；2.不应该出现重名；
        /// </remarks>
        public static SubscriberHandler Subscribe(string source, IEnumerable<string> topics, Action<string, string, string> receiveDelegate)
        {
            if (receiveDelegate == null)
            {
                throw new ArgumentNullException(nameof(receiveDelegate));
            }

            LogHelper<ZSocket>.Debug($"创建 MQ 消息订阅者：{source} ...");

            try
            {
                // 创建订阅者、订阅主题、监听
                ZSocket subSocket = new ZSocket(ZSocketType.SUB);
                subSocket.Connect(MQAddress);
                topics.All(topic =>
                {
                    subSocket.Subscribe(topic);
                    return true;
                });
                LogHelper<ZSocket>.Debug($"创建 MQ 消息订阅者成功");

                return new SubscriberHandler(source, subSocket, receiveDelegate);
            }
            catch (Exception ex)
            {
                LogHelper<DefaultLogSource>.ErrorException(ex, $"创建订阅者失败 {source}：");
                return default;
            }
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="source"></param>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        public static void Publish(string source, string topic, string message)
        {
            LogHelper<ZSocket>.Debug($"{source} 开始发布消息：{topic} - {message}");

            try
            {
                // 拼接消息时应确保 topic 在第一位，否则将影响 MQ 订阅者的匹配和接收
                using (var frame = new ZFrame($"{topic}{Separator[0]}{source}{Separator[0]}{message}"))
                {
                    PublisherSocket.Send(frame);
                }

                LogHelper<ZSocket>.Debug($"{source} 发布消息 {topic} 成功：");
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"{source} 发布消息 {topic} 失败：");
            }
        }
    }
}
