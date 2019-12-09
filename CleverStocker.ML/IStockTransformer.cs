using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票训练器
    /// </summary>
    public interface IStockTransformer
    {
        /// <summary>
        /// Gets MLContext
        /// </summary>
        MLContext MLContext { get; }

        /// <summary>
        /// Gets Transformer
        /// </summary>
        ITransformer Transformer { get; }

        /// <summary>
        /// Gets Estimator
        /// </summary>
        IEstimator<ITransformer> Estimator { get; }

        /// <summary>
        /// 初始化 Estimator
        /// </summary>
        void InitializeEstimator();

        // TODO: 增加模型评估方法，返回模型得分
    }
}
