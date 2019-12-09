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

        /// <summary>
        /// 评估
        /// </summary>
        /// <returns></returns>
        (double L1, double L2, double RMS, double LossFunction, double R2) Evaluate();
    }
}
