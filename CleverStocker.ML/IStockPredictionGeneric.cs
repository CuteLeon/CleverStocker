using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 股票预测器
    /// </summary>
    /// <typeparam name="TInput">输入模型</typeparam>
    /// <typeparam name="TOutput">输出模型</typeparam>
    public interface IStockPredictionGeneric<TInput, TOutput> : IStockPrediction
        where TInput : class
        where TOutput : class, new()
    {
        /// <summary>
        /// Gets 预测引擎
        /// </summary>
        PredictionEngine<TInput, TOutput> PredictionEngine { get; }

        /// <summary>
        /// 预测
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        TOutput Predict(TInput input);
    }
}
