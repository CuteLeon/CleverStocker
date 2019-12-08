using Microsoft.ML;

namespace CleverStocker.ML.NextOpenPrice
{
    public class NOPStockTransformer : StockTransformerBase<NOPInput>
    {
        /// <inheritdoc/>
        public override IEstimator<ITransformer> CreateEstimator()
        {
            // TODO: 配置估算器
            return default;
        }
    }
}
