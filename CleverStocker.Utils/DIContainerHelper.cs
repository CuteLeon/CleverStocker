using System;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace CleverStocker.Utils
{
    /// <summary>
    /// DI 容器
    /// </summary>
    /// <see cref="https://autofac.readthedocs.io/en/latest/configuration/xml.html#quick-start"/>
    public static class DIContainerHelper
    {
        /// <summary>
        /// 依赖注入容器创建者
        /// </summary>
        private static readonly ContainerBuilder Builder = null;

        /// <summary>
        /// 依赖注入容器
        /// </summary>
        /// <remarks>注册服务后 Build 容器</remarks>
        private static readonly IContainer Container = null;

        /// <summary>
        /// Initializes static members of the <see cref="DIContainerHelper"/> class.
        /// </summary>
        static DIContainerHelper()
        {
            LogHelper<DefaultLogSource>.Debug("创建依赖注入容器 ...");

            Builder = new ContainerBuilder();
            RegistServices();
            Container = Builder.Build();

            LogHelper<DefaultLogSource>.Debug("创建依赖注入容器完成");
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns></returns>
        public static TService Resolve<TService>()
        {
            TService service = default;

            try
            {
                bool result = false;

                lock (Container)
                {
                    result = Container.TryResolve(out service);
                }

                if (!result)
                {
                    LogHelper<DefaultLogSource>.Error($"DI容器获取未注册的服务：{typeof(TService).FullName}");
                }
            }
            catch (Exception ex)
            {
                LogHelper<DefaultLogSource>.ErrorException(ex, $"DI容器获取服务 {typeof(TService).FullName} 失败：");
            }

            return service;
        }

        /// <summary>
        /// 调用
        /// </summary>
        public static void Call()
        {
        }

        /// <summary>
        /// 注册服务
        /// </summary>
        private static void RegistServices()
        {
            /* 生命周期
             * builder.RegisterType<XueQiuStockSpider>().As<IStockerService>().InstancePerDependency();
             *     IRegistrationBuilder.SingleInstance();   // 单实例
             *     IRegistrationBuilder.InstancePerLifetimeScope(); // 每个生命周期内唯一
             *     IRegistrationBuilder.InstancePerDependency();    // 每次获取时新建
             *     IRegistrationBuilder.InstancePerMatchingLifetimeScope(); // 多个标记匹配的生命周期内唯一
             *     IRegistrationBuilder.InstancePerOwned<T>();  // 对每个拥有者类型唯一
             */

            LogHelper<DefaultLogSource>.Debug("开始注册服务 ...");
            var config = new ConfigurationBuilder()
                .AddJsonFile("Autofac.json");
            var configRoot = config.Build();
            var module = new ConfigurationModule(configRoot);
            Builder.RegisterModule(module);
        }
    }
}
