using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票预测器
    /// </summary>
    /// <typeparam name="TIn">输入模型</typeparam>
    /// <typeparam name="TOut">输出模型</typeparam>
    public interface IStockPredictionGeneric<TIn, TOut> : IStockPrediction
        where TIn : class
        where TOut : class, new()
    {
        /// <summary>
        /// Gets 预测引擎
        /// </summary>
        PredictionEngine<TIn, TOut> PredictionEngine { get; }

        /// <summary>
        /// 预测
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
        TOut Predict(TIn feature);
    }
}
