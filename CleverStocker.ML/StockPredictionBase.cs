using Microsoft.ML;

namespace CleverStocker.ML
{
    /// <summary>
    /// 预测器基类
    /// </summary>
    /// <typeparam name="TIn">输入模型</typeparam>
    /// <typeparam name="TOut">输出模型</typeparam>
    public abstract class StockPredictionBase<TIn, TOut> : IStockPredictionGeneric<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        /// <inheritdoc/>
        public MLContext MLContext { get; protected set; }

        /// <inheritdoc/>
        public ITransformer Transformer { get; protected set; }

        /// <inheritdoc/>
        public PredictionEngine<TIn, TOut> PredictionEngine { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockPredictionBase{TIn, TOut}"/> class.
        /// </summary>
        public StockPredictionBase()
        {
            this.MLContext = new MLContext();
        }

        /// <inheritdoc/>
        public void LoadModelToPredictionEngine(string modelPath)
        {
            this.Transformer = this.MLContext.Model.Load(modelPath, out var _);
            this.PredictionEngine = this.MLContext.Model.CreatePredictionEngine<TIn, TOut>(this.Transformer);
        }

        /// <inheritdoc/>
        public TOut Predict(TIn feature)
            => this.PredictionEngine.Predict(feature);
    }
}
