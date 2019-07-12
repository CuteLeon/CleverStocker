using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 表达式树克隆助手
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    /// <typeparam name="TTarget">目标类型</typeparam>
    public class ExpressionCloneHelper<TSource, TTarget>
    {
        /// <summary>
        /// 映射方法
        /// </summary>
        /// <remarks>会缓存在静态泛型类中</remarks>
        private static readonly Func<TSource, TTarget> MapFunc = CreateMapExpression();

        /// <summary>
        /// 克隆
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TTarget Clone(TSource source)
            => MapFunc(source);

        /// <summary>
        /// 创建映射表达式
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns></returns>
        /// <remarks>克隆时将忽略虚拟属性，以免克隆大量 EF6 导航属性数据</remarks>
        public static Func<TSource, TTarget> CreateMapExpression()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "source");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();

            foreach (var targetProperty in typeof(TTarget).GetProperties()
                .Where(p => p.CanWrite && !p.GetSetMethod().IsVirtual))
            {
                MemberExpression propertyExpression = Expression.Property(
                    parameterExpression,
                    typeof(TSource).GetProperty(targetProperty.Name));

                MemberBinding memberBinding = Expression.Bind(targetProperty, propertyExpression);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(
                Expression.New(typeof(TTarget)),
                memberBindingList);

            Expression<Func<TSource, TTarget>> mapExpression = Expression.Lambda<Func<TSource, TTarget>>(
                memberInitExpression,
                new ParameterExpression[] { parameterExpression });

            Func<TSource, TTarget> mapFunc = mapExpression.Compile();
            return mapFunc;
        }
    }
}
