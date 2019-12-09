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
            // 配置特征列
            const string FeaturesName = "Features";
            var updateTimeFeature = $"{nameof(NOPInput.UpdateTime)}_Feature";
            var features = new[]
            {
                updateTimeFeature,
                nameof(NOPInput.OpenningPrice),
                nameof(NOPInput.ClosingPrice),
                nameof(NOPInput.HighestPrice),
                nameof(NOPInput.LowestPrice),
                nameof(NOPInput.Volume),
            };

            // 配置训练管道
            var dataProcessPipeline = this.MLContext.Transforms
                .Text.FeaturizeText(updateTimeFeature, nameof(NOPInput.UpdateTime))
                .Append(this.MLContext.Transforms.Concatenate(FeaturesName, features));

            // 配置训练算法
            var trainer = this.MLContext.Regression.Trainers.LightGbm(nameof(NOPInput.NextOpenningPrice), FeaturesName);
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            return trainingPipeline;
        }
    }
}
