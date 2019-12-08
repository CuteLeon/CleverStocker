using System.Collections.Generic;
using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 训练器基类
    /// </summary>
    /// <typeparam name="TInput">输入模型</typeparam>
    public abstract class StockTransformerBase<TInput> : IStockTransformerGeneric<TInput>
        where TInput : class
    {
        /// <inheritdoc/>
        public MLContext MLContext { get; protected set; }

        /// <inheritdoc/>
        public ITransformer Transformer { get; protected set; }

        /// <inheritdoc/>
        public IDataView TrainingData { get; protected set; }

        /// <inheritdoc/>
        public IEstimator<ITransformer> Estimator { get; protected set; }

        /// <inheritdoc/>
        public void InitializeEstimator()
        {
            this.Estimator = this.CreateEstimator();
        }

        /// <summary>
        /// 创建 Estimator
        /// </summary>
        /// <returns></returns>
        public abstract IEstimator<ITransformer> CreateEstimator();

        /// <inheritdoc/>
        public void Fit(IEnumerable<TInput> inputs)
        {
            this.TrainingData = this.MLContext.Data.LoadFromEnumerable(inputs);
            this.Transformer = this.Estimator.Fit(this.TrainingData);
        }

        /// <inheritdoc/>
        public void SaveModel(string modelPath)
        {
            this.MLContext.Model.Save(this.Transformer, this.TrainingData.Schema, modelPath);
        }
    }
}
