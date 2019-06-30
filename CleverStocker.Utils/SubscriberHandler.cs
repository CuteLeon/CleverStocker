using System;
using System.Threading.Tasks;
using ZeroMQ;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 订阅者操作器
    /// </summary>
    public class SubscriberHandler : IDisposable
    {
        /// <summary>
        /// 名称
        /// </summary>
        private readonly string source;

        /// <summary>
        /// 订阅者
        /// </summary>
        private readonly ZSocket subscriberSocket;

        /// <summary>
        /// 消息接收委托 (发布者，主题，消息)
        /// </summary>
        private readonly Action<string, string, string> receiveDelegate;

        /// <summary>
        /// 接收任务
        /// </summary>
        private readonly Task receiveTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberHandler"/> class.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="socket"></param>
        /// <param name="delegate"></param>
        public SubscriberHandler(string source, ZSocket socket, Action<string, string, string> @delegate)
        {
            this.source = source;
            this.subscriberSocket = socket;
            this.receiveDelegate = @delegate;

            this.receiveTask = this.StartSubscriberReceiveTask();
        }

        /// <summary>
        /// 连接
        /// </summary>
        public void Connect()
        {
            LogHelper<ZSocket>.Debug($"订阅者连接：{this.source} ...");

            try
            {
                this.subscriberSocket.Connect(MQHelper.MQAddress);
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"订阅者连接失败：");
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            LogHelper<ZSocket>.Debug($"断开订阅者连接：{this.source} ...");

            try
            {
                this.subscriberSocket.Disconnect(MQHelper.MQAddress);
            }
            catch (Exception ex)
            {
                LogHelper<ZSocket>.ErrorException(ex, $"断开订阅者连接失败：");
            }
        }

        /// <summary>
        /// 开始订阅者接收任务
        /// </summary>
        /// <returns></returns>
        private Task StartSubscriberReceiveTask()
            => Task.Factory.StartNew(() =>
                {
                    LogHelper<ZSocket>.Debug($"启动订阅者 {this.source} 接收任务 (TaskId = {Task.CurrentId}) ...");

                    string message;
                    string[] messages;

                    while (true)
                    {
                        using (var response = this.subscriberSocket.ReceiveFrame())
                        {
                            message = response.ReadString();
                            messages = message.Split(MQHelper.Separator, 3);

                            if (messages.Length == 3)
                            {
                                // 自动过滤自己发布的消息，避免消息循环
                                if (messages[1] == this.source)
                                {
                                    break;
                                }

                                try
                                {
                                    this.receiveDelegate.DynamicInvoke(messages[1], messages[0], messages[2]);
                                }
                                catch (Exception ex)
                                {
                                    // 仅输出日志，不要继续上抛异常，否则将中断 Task
                                    LogHelper<SubscriberHandler>.ErrorException(ex, $"{this.source} 处理 {message[0]} 发来的消息失败 {messages[1]}：");
                                }
                            }
                            else
                            {
                                LogHelper<ZSocket>.Error($"收到无法分离主题的消息：{message}");
                                break;
                            }
                        }
                    }
                });

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.Disconnect();
                this.subscriberSocket.Close();
                this.subscriberSocket.Dispose();
            }
            finally
            {
            }
        }
    }
}
