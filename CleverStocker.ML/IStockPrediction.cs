using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票预测器
    /// </summary>
    public interface IStockPrediction
    {
        /// <summary>
        /// Gets MLContext
        /// </summary>
        MLContext MLContext { get; }

        /// <summary>
        /// Gets transformer
        /// </summary>
        ITransformer Transformer { get; }

        /// <summary>
        /// 加载模型至预测引擎
        /// </summary>
        /// <param name="modelPath"></param>
        void LoadModelToPredictionEngine(string modelPath);
    }
}
