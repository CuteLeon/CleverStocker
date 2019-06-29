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
        private readonly string name;

        /// <summary>
        /// 订阅者
        /// </summary>
        private readonly ZSocket subscriberSocket;

        /// <summary>
        /// 消息接收委托
        /// </summary>
        private readonly Action<string, string> receiveDelegate;

        /// <summary>
        /// 接收任务
        /// </summary>
        private readonly Task receiveTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriberHandler"/> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="socket"></param>
        /// <param name="delegate"></param>
        public SubscriberHandler(string name, ZSocket socket, Action<string, string> @delegate)
        {
            this.name = name;
            this.subscriberSocket = socket;
            this.receiveDelegate = @delegate;

            this.receiveTask = this.StartSubscriberReceiveTask();
        }

        /// <summary>
        /// 连接
        /// </summary>
        public void Connect()
        {
            LogHelper<ZSocket>.Debug($"订阅者连接：{this.name} ...");

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
            LogHelper<ZSocket>.Debug($"断开订阅者连接：{this.name} ...");

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
        {
            Task task = Task.Factory.StartNew(
                () =>
                {
                    LogHelper<ZSocket>.Debug($"启动订阅者 {this.name} 接收任务 (TaskId = {Task.CurrentId}) ...");

                    string message;
                    string[] messages;

                    while (true)
                    {
                        using (var response = this.subscriberSocket.ReceiveFrame())
                        {
                            message = response.ReadString();
                            messages = message.Split(MQHelper.Separator, 2);

                            switch (messages.Length)
                            {
                                case 2:
                                    {
                                        try
                                        {
                                            this.receiveDelegate.DynamicInvoke(messages[0], messages[1]);
                                        }
                                        finally
                                        {
                                        }

                                        break;
                                    }

                                case 1:
                                    {
                                        try
                                        {
                                            this.receiveDelegate.DynamicInvoke(string.Empty, message);
                                        }
                                        finally
                                        {
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        LogHelper<ZSocket>.Error($"收到无法分离主题的消息：{message}");
                                        break;
                                    }
                            }
                        }
                    }
                });

            return task;
        }

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
