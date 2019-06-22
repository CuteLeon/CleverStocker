using System;
using Autofac;
using CleverStocker.Services;
using CleverStocker.Spider.XueQiu;
using CleverStocker.Utils;

namespace CleverStocker.Client.Configs
{
    // TODO: 精修 DI 容器
    // TODO: 使用外部文件配置服务类型，避免 Client 项目直接与实现的引用

    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public static class DIContainer
    {
        /// <summary>
        /// Initializes static members of the <see cref="DIContainer"/> class.
        /// </summary>
        static DIContainer()
        {
            LogHelper<DefaultLogSource>.Debug("创建依赖注入容器 ...");
            DIContainerBuilder = new ContainerBuilder();
            RegistServices();
            Container = DIContainerBuilder.Build();
            LogHelper<DefaultLogSource>.Debug("创建依赖注入容器完成");
        }

        /// <summary>
        /// Gets 依赖注入容器创建者
        /// </summary>
        private static ContainerBuilder DIContainerBuilder { get; } = null;

        /// <summary>
        /// Gets 依赖注入容器
        /// </summary>
        /// <remarks>注册服务后 Build 容器</remarks>
        private static IContainer Container { get; } = null;

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
        public static void Call() { }

        /// <summary>
        /// 注册服务
        /// </summary>
        private static void RegistServices()
        {
            /* 生命周期
             * IRegistrationBuilder.SingleInstance();   单实例
             * IRegistrationBuilder.InstancePerLifetimeScope(); 每个 LifetimeScope 内唯一
             * IRegistrationBuilder.InstancePerDependency();    每次获取时新建
             * IRegistrationBuilder.InstancePerMatchingLifetimeScope(); 多个标记匹配的 LifetimeScope 内唯一
             * IRegistrationBuilder.InstancePerOwned<T>();  对每个拥有者类型唯一
             */

            LogHelper<DefaultLogSource>.Debug("开始注册服务 ...");
            DIContainerBuilder.RegisterType<XueQiuStockSpider>().As<IStockerService>().InstancePerDependency();
        }
    }
}
