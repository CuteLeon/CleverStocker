using System.Collections.Generic;
using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票训练器
    /// </summary>
    /// <typeparam name="TIn">输入模型</typeparam>
    /// <typeparam name="TOut">输出模型</typeparam>
    public interface IStockTransformerGeneric<TIn, TOut> : IStockTransformer
        where TIn : class
        where TOut : class, new()
    {
        /// <summary>
        /// Gets 训练数据
        /// </summary>
        IDataView TrainingData { get; }

        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="inputs"></param>
        void Fit(IEnumerable<TIn> inputs);

        /// <summary>
        /// 保存模型
        /// </summary>
        /// <param name="modelPath"></param>
        void SaveModel(string modelPath);
    }
}
