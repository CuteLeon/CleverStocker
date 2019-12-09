using System.Linq;
using Microsoft.ML;

namespace CleverStocker.ML.NextOpenPrice
{
    // TODO: 自动选择最优算法 https://www.cnblogs.com/seabluescn/p/10995991.html

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
            // .Append(this.MLContext.Transforms.NormalizeMinMax(FeaturesName, FeaturesName))
            // .AppendCacheCheckpoint(this.MLContext);

            // 配置训练算法
            var trainer = this.MLContext.Regression.Trainers.LightGbm(nameof(NOPInput.NextOpenningPrice), FeaturesName);
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            return trainingPipeline;
        }

        /// <inheritdoc/>
        public override (double L1, double L2, double RMS, double LossFunction, double R2) Evaluate()
        {
            var crossValidationResults = this.MLContext.Regression.CrossValidate(
                this.TrainingData,
                this.Estimator,
                5,
                nameof(NOPInput.NextOpenningPrice));

            var l1 = crossValidationResults.Average(r => r.Metrics.MeanAbsoluteError);
            var l2 = crossValidationResults.Average(r => r.Metrics.MeanSquaredError);
            var rms = crossValidationResults.Average(r => r.Metrics.RootMeanSquaredError);
            var lossFunction = crossValidationResults.Average(r => r.Metrics.LossFunction);
            var r2 = crossValidationResults.Average(r => r.Metrics.RSquared);

            return (l1, l2, rms, lossFunction, r2);
        }
    }
}
