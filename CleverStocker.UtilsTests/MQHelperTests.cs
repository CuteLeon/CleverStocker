using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.Utils.Tests
{
    [TestClass()]
    public class MQHelperTests
    {
        [TestMethod()]
        public void MQHelperUnitTests()
        {
            int counter = 0;

            Console.WriteLine("绑定发布者 ...");
            MQHelper.BindPublisher();

            Console.WriteLine("订阅主题 ...");
            var handler = MQHelper.Subscribe("测试订阅者", new[] { "1" }, (source, topic, message) =>
                {
                    counter++;
                    Console.WriteLine($"收到 {source} 发来的消息：{topic} - {message}");
                });

            // 发布者和订阅者任何一端断开或重连，另一端不需要任何操作，可以继续收发
            MQHelper.Publish("测试发布者", "1.1", "股票打新咯！！！-1");

            MQHelper.DisconnectPublisher();
            Thread.Sleep(100);
            MQHelper.Publish("测试发布者", "1.2", "股票打新咯！！！-2");
            Thread.Sleep(100);

            MQHelper.BindPublisher();
            Thread.Sleep(100);
            MQHelper.Publish("测试发布者", "1.3", "股票打新咯！！！-3");
            Thread.Sleep(100);

            handler.Disconnect();
            Thread.Sleep(100);
            MQHelper.Publish("测试发布者", "1.4", "股票打新咯！！！-4");
            Thread.Sleep(100);

            Thread.Sleep(100);
            handler.Connect();
            Thread.Sleep(100);
            MQHelper.Publish("测试发布者", "1.5", "股票打新咯！！！-5");

            // 自动过滤自己发布的消息，避免消息循环
            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", "1.6", "股票打新咯！！！-6");
            Thread.Sleep(100);

            // 释放订阅者
            handler.Dispose();

            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", "1.7", "股票打新咯！！！-7");

            Console.WriteLine($"测试结束，计数器: {counter}");

            // 仅收到 1、3、5 消息即为正常
            Assert.AreEqual(3, counter);
        }
    }
}