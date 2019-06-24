using System;
using System.IO;
using Autofac;
using Autofac.Builder;
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
        /// 生命周期
        /// </summary>
        public enum LifetimeScopes
        {
            /// <summary>
            /// 每次生命周期
            /// </summary>
            PerDependency = 0,

            /// <summary>
            /// 每个生命周期
            /// </summary>
            PerLifetimeScope = 1,

            /// <summary>
            /// 单实例
            /// </summary>
            SingleInstance = 2,
        }

        #region 属性

        /// <summary>
        /// Gets 依赖注入容器创建者
        /// </summary>
        public static ContainerBuilder Builder { get; private set; } = new ContainerBuilder();

        /// <summary>
        /// Gets 依赖注入容器
        /// </summary>
        /// <remarks>注册服务后 Build 容器</remarks>
        public static IContainer Container { get; private set; } = null;
        #endregion

        #region 注册

        /// <summary>
        /// 注册实现为抽象
        /// </summary>
        /// <typeparam name="TImplementer">实现类型</typeparam>
        /// <typeparam name="TAbstract">接口类型</typeparam>
        /// <param name="scopes">生命周期</param>
        /// <param name="name">名称</param>
        public static void RegisteTypeAsType<TImplementer, TAbstract>(
            LifetimeScopes scopes = LifetimeScopes.PerDependency,
            string name = "")
        {
            var register = Builder.RegisterType<TImplementer>().AsSelf();

            if (string.IsNullOrEmpty(name))
            {
                register = register.As<TAbstract>();
            }
            else
            {
                register = register.Named<TAbstract>(name);
            }

            SetLifetimeScope(register, scopes);
        }

        /// <summary>
        /// 注册实现为抽象
        /// </summary>
        /// <typeparam name="TImplementer">实现类型</typeparam>
        /// <param name="scopes">生命周期</param>
        /// <param name="abstractTypes">抽象类型</param>
        public static void RegisteTypeAsTypes<TImplementer>(
            LifetimeScopes scopes = LifetimeScopes.PerDependency,
            params Type[] abstractTypes)
        {
            var register = Builder.RegisterType<TImplementer>();

            if (abstractTypes.Length > 0)
            {
                register = register.As(abstractTypes);
            }

            SetLifetimeScope(register, scopes);
        }

        /// <summary>
        /// 注册泛型实现
        /// </summary>
        /// <param name="implemeterType"></param>
        /// <param name="abstractType"></param>
        /// <param name="scopes"></param>
        /// <param name="name"></param>
        public static void RegisterGenericAsType(
            Type implemeterType,
            Type abstractType,
            LifetimeScopes scopes,
            string name = "")
        {
            var register = Builder.RegisterGeneric(implemeterType);

            if (string.IsNullOrEmpty(name))
            {
                register = register.As(abstractType);
            }
            else
            {
                register = register.Named(name, abstractType);
            }

            SetLifetimeScope(register, scopes);
        }

        /// <summary>
        /// 注册实例为抽象
        /// </summary>
        /// <typeparam name="TInstance">实例类型</typeparam>
        /// <typeparam name="TAbstract">接口类型</typeparam>
        /// <param name="instance"></param>
        /// <param name="name">名称</param>
        public static void RegisteInstanceAsType<TInstance, TAbstract>(
            TInstance instance,
            string name = "")
            where TInstance : class
        {
            var register = Builder.RegisterInstance(instance).AsSelf();

            if (string.IsNullOrEmpty(name))
            {
                _ = register.As<TAbstract>();
            }
            else
            {
                _ = register.Named<TAbstract>(name);
            }
        }

        /// <summary>
        /// 注册实现为抽象
        /// </summary>
        /// <typeparam name="TInstance">实例类型</typeparam>
        /// <param name="instance"></param>
        /// <param name="abstractTypes">抽象类型</param>
        public static void RegisteInstanceAsTypes<TInstance>(
            TInstance instance,
            params Type[] abstractTypes)
            where TInstance : class
        {
            var register = Builder.RegisterInstance(instance);

            if (abstractTypes.Length > 0)
            {
                _ = register.As(abstractTypes);
            }
        }
        #endregion

        #region 判断

        /// <summary>
        /// 是否注册服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns></returns>
        public static bool IsRegistered<TService>()
            => Container.IsRegistered<TService>();

        /// <summary>
        /// 是否注册服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        public static bool IsRegistered(Type serviceType)
            => Container.IsRegistered(serviceType);

        /// <summary>
        /// 是否注册服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegisteredWithName<TService>(string name)
            => Container.IsRegisteredWithName<TService>(name);

        /// <summary>
        /// 是否注册服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsRegisteredWithName(Type serviceType, string name)
            => Container.IsRegisteredWithName(name, serviceType);
        #endregion

        #region 判决

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns></returns>
        public static TService Resolve<TService>()
        {
            return (TService)Resolve(typeof(TService));
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static object Resolve(Type serviceType)
        {
            object service = default;

            try
            {
                bool result = false;

                lock (Container)
                {
                    result = Container.TryResolve(serviceType, out service);
                }

                if (!result)
                {
                    LogHelper<DefaultLogSource>.Error($"DI容器获取未注册的服务：{serviceType.FullName}");
                }
            }
            catch (Exception ex)
            {
                LogHelper<DefaultLogSource>.ErrorException(ex, $"DI容器获取服务 {serviceType.FullName} 失败：");
            }

            return service;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TService Resolve<TService>(string name)
        {
            return (TService)Resolve(typeof(TService), name);
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object Resolve(Type serviceType, string name)
        {
            object service = default;

            try
            {
                bool result = false;

                lock (Container)
                {
                    result = Container.TryResolveNamed(name, serviceType, out service);
                }

                if (!result)
                {
                    LogHelper<DefaultLogSource>.Error($"DI容器获取未注册的服务：{serviceType.FullName}");
                }
            }
            catch (Exception ex)
            {
                LogHelper<DefaultLogSource>.ErrorException(ex, $"DI容器获取服务 {serviceType.FullName} 失败：");
            }

            return service;
        }
        #endregion

        #region 建造

        /// <summary>
        /// 创建容器
        /// </summary>
        public static void Build()
        {
            Container = Builder.Build();
        }

        /// <summary>
        /// 清空
        /// </summary>
        public static void Clear()
        {
            try
            {
                Builder = new ContainerBuilder();
                Container?.Disposer?.Dispose();
                Container?.Dispose();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 从外部配置注册服务
        /// </summary>
        public static void RegistServicesFromConfig()
        {
            const string jsonFileName = "Autofac.json";

            if (File.Exists(jsonFileName))
            {
                LogHelper<DefaultLogSource>.Debug("开始从外部配置注册服务 ...");
                var config = new ConfigurationBuilder()
                    .AddJsonFile(jsonFileName);
                var configRoot = config.Build();
                var module = new ConfigurationModule(configRoot);
                Builder.RegisterModule(module);
                LogHelper<DefaultLogSource>.Debug("从外部配置注册服务完成");
            }
            else
            {
                LogHelper<DefaultLogSource>.Warn($"不存在 Autofac 配置文件：{jsonFileName}");
            }
        }
        #endregion

        /// <summary>
        /// 注册生命周期
        /// </summary>
        /// <typeparam name="TLimit">TLimit</typeparam>
        /// <typeparam name="TActivatorData">TActivatorData</typeparam>
        /// <typeparam name="TRegistrationStyle">TRegistrationStyle</typeparam>
        /// <param name="registration"></param>
        /// <param name="scopes"></param>
        /// <returns></returns>
        private static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> SetLifetimeScope<TLimit, TActivatorData, TRegistrationStyle>(
            IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration,
            LifetimeScopes scopes)
        {
            switch (scopes)
            {
                case LifetimeScopes.PerDependency:
                    {
                        registration = registration.InstancePerDependency();
                        break;
                    }

                case LifetimeScopes.PerLifetimeScope:
                    {
                        registration = registration.InstancePerLifetimeScope();
                        break;
                    }

                case LifetimeScopes.SingleInstance:
                    {
                        registration = registration.SingleInstance();
                        break;
                    }

                default:
                    break;
            }

            return registration;
        }
    }
}
