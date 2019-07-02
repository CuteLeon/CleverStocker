using System;
using System.Threading.Tasks;
using CleverStocker.Common;
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
        /// 退出指令
        /// </summary>
        private readonly string exitCommand;

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
            this.exitCommand = $"{MQTopics.TopicMQCommandExit}.{source}";
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
                LogHelper<SubscriberHandler>.ErrorException(ex, $"订阅者连接失败：");
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            LogHelper<SubscriberHandler>.Debug($"断开订阅者连接：{this.source} ...");

            try
            {
                this.subscriberSocket.Disconnect(MQHelper.MQAddress);
            }
            catch (Exception ex)
            {
                LogHelper<SubscriberHandler>.ErrorException(ex, $"断开订阅者连接失败：");
            }
        }

        /// <summary>
        /// 开始订阅者接收任务
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 需要给每个 MQ 订阅者实现一个接收消息的异步线程，且这个线程大部分时间是被阻塞的。
        /// Windows 系统没每个进程分配 2GB 的用户态内存，每个线程的默认栈代销为 1024KB (1MB)，
        /// 所以每个进程最多拥有不超过 2048 个线程。
        /// 可以在日志中每个接受者的输出日志，得知此消息接收任务所在线程。
        /// </remarks>
        private Task StartSubscriberReceiveTask()
            => Task.Factory.StartNew(() =>
                {
                    LogHelper<SubscriberHandler>.Debug($"启动订阅者 {this.source} 接收任务 (TaskId = {Task.CurrentId}) ...");

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
                                if (string.Equals(messages[1], this.source, StringComparison.OrdinalIgnoreCase))
                                {
                                    /* 无法外部直接关闭阻塞的异步线程，在需要关闭时，需要自己通过 MQ 发布指令关闭订阅者
                                     * 需要判断主题与退出指令相等，而不是主题以退出指令开始，否则会因为收到子主题而错误退出
                                     */
                                    if (string.Equals(messages[0], this.exitCommand, StringComparison.OrdinalIgnoreCase))
                                    {
                                        LogHelper<SubscriberHandler>.Debug($"收到 MQ 退出指令，跳出 MQ 消息接收循环 (TaskId = {Task.CurrentId}) ...");
                                        break;
                                    }

                                    continue;
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
                /* 关闭时需要此订阅者连接到发布者，否则可能错过退出指令
                 * ZeroMQ 性能极快，如果立即连接并订阅时，可能会在订阅者 Connect() 之前发布者就 Send() 了，导致订阅者无法如期接收到退出指令
                 */
                MQHelper.Publish(this.source, this.exitCommand, "退出当前 MQ 指令接收线程");
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
