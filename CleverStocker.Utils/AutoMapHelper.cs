using System;
using System.Collections.Generic;
using AutoMapper;

namespace CleverStocker.Utils
{
    public static class AutoMapHelper
    {
        private static IMapper mapper;

        /// <summary>
        /// 配置对应关系
        /// </summary>
        /// <param name="typeTuples"></param>
        public static void ConfigMappers(IEnumerable<(Type SourceType, Type TargetType)> typeTuples)
        {
            MapperConfiguration configuration = new MapperConfiguration(expression =>
            {
                foreach ((Type SourceType, Type TargetType) tuple in typeTuples)
                {
                    expression.CreateMap(tuple.SourceType, tuple.TargetType);
                }
            });

#if DEBUG
            // configuration.AssertConfigurationIsValid();
#endif

            mapper = configuration.CreateMapper();
        }

        /// <summary>
        /// 数据对应到新对象
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget Map<TTarget>(object source)
        {
            return mapper.Map<TTarget>(source);
        }

        /// <summary>
        /// 数据对应到已有对象
        /// </summary>
        /// <typeparam name="TTarget">目标类型</typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TTarget Map<TTarget>(object source, TTarget destination)
        {
            return mapper.Map(source, destination);
        }
    }
}
