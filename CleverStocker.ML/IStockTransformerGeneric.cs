using System.Collections.Generic;
using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票训练器
    /// </summary>
    /// <typeparam name="TInput">输入模型</typeparam>
    public interface IStockTransformerGeneric<TInput> : IStockTransformer
        where TInput : class
    {
        /// <summary>
        /// Gets 训练数据
        /// </summary>
        IDataView TrainingData { get; }

        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="inputs"></param>
        void Fit(IEnumerable<TInput> inputs);

        /// <summary>
        /// 保存模型
        /// </summary>
        /// <param name="modelPath"></param>
        void SaveModel(string modelPath);
    }
}
