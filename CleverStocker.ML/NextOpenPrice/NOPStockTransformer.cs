using Microsoft.ML;

namespace CleverStocker.ML.NextOpenPrice
{
    /// <summary>
    /// 下次开盘价训练器
    /// </summary>
    public class NOPStockTransformer : StockTransformerBase<NOPInput>, INOPStockTransformer
    {
        /// <inheritdoc/>
        public override IEstimator<ITransformer> CreateEstimator()
        {
            // TODO: 配置估算器
            return default;
        }
    }
}
