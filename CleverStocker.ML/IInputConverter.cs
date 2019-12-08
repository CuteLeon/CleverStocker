using System.Collections.Generic;

namespace CleverStocker.ML
{
    /// <summary>
    /// 输入模型转换器
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    /// <typeparam name="TInput">输入类型</typeparam>
    public interface IInputConverter<TSource, TInput>
    {
        /// <summary>
        /// 转换输入模型
        /// </summary>
        /// <param name="sources"></param>
        /// <returns></returns>
        IEnumerable<TInput> ConvertInputs(IEnumerable<TSource> sources);

        /// <summary>
        /// 转换输入模型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        TInput ConvertInput(TSource source);
    }
}
