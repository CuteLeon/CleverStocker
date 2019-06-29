using System;
using System.Threading;
using CleverStocker.Common;
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
            var handler = MQHelper.Subscribe("测试订阅者", new[] { MQTopics.TopicStock }, (topic, message) =>
               {
                   counter++;
                   Console.WriteLine($"收到消息：{topic} - {message}");
               });

            MQHelper.Publish("测试订阅者", MQTopics.TopicStockAdd, "股票打新咯！！！-1");

            MQHelper.DisconnectPublisher();
            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", MQTopics.TopicStockAdd, "股票打新咯！！！-2");
            Thread.Sleep(100);

            MQHelper.BindPublisher();
            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", MQTopics.TopicStockAdd, "股票打新咯！！！-3");
            Thread.Sleep(100);

            handler.Disconnect();
            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", MQTopics.TopicStockAdd, "股票打新咯！！！-4");
            Thread.Sleep(100);

            Thread.Sleep(100);
            handler.Connect();
            Thread.Sleep(100);
            MQHelper.Publish("测试订阅者", MQTopics.TopicStockAdd, "股票打新咯！！！-5");

            Console.WriteLine($"测试结束，计数器: {counter}");

            Assert.IsTrue(counter > 0);
        }
    }
}