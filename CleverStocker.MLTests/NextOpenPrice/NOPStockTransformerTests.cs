using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CleverStocker.MLTests;
using CleverStocker.Model;
using CleverStocker.Utils;
using Microsoft.ML;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleverStocker.ML.NextOpenPrice.Tests
{
    [TestClass()]
    public class NOPStockTransformerTests
    {
        [TestMethod()]
        public void AutoMLTest()
        {
            string content = File.ReadAllText(@".\Datas\NOPTrainData.json");
            List<NOPInput> trainData = SerializerHelper.Deserialize<List<NOPInput>>(content);
            content = File.ReadAllText(@".\Datas\NOPTestData.json");
            List<NOPInput> testData = SerializerHelper.Deserialize<List<NOPInput>>(content);
            Console.WriteLine($"训练数据：{trainData.Count} 个，测试数据：{testData.Count} 个");

            MLContext mlContext = new MLContext();
            var progressHandler = new RegressionExperimentProgressHandler();
            uint ExperimentTime = 200;

            IDataView trainDataView = mlContext.Data.LoadFromEnumerable(trainData);
            IDataView testDataView = mlContext.Data.LoadFromEnumerable(testData);

            ExperimentResult<RegressionMetrics> experimentResult = mlContext.Auto()
               .CreateRegressionExperiment(ExperimentTime)
               .Execute(trainDataView, nameof(NOPInput.NextOpenningPrice), progressHandler: progressHandler);

            var topRuns = experimentResult.RunDetails
                .Where(r => r.ValidationMetrics != null && !double.IsNaN(r.ValidationMetrics.RSquared))
                .OrderByDescending(r => r.ValidationMetrics.RSquared)
                .ToList();

            Console.WriteLine("训练模型按照 R-Squared 排序：");
            foreach (var run in topRuns)
            {
                Console.WriteLine($"{run.TrainerName}\t{run.RuntimeInSeconds}s\t{run.ValidationMetrics.RSquared}");
            }

            Console.WriteLine("最佳模型：");
            Console.WriteLine(experimentResult.BestRun.TrainerName);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<NOPInput, NOPOutput>(experimentResult.BestRun.Model);
            var output = predictionEngine.Predict(testData.First());
            Console.WriteLine($"预测结果：{output.NextOpenPrice}");
        }


        /// <summary>
        /// 保存训练和测试数据
        /// </summary>
        /// <param name="recentQuotas"></param>
        public void SaveTrainTestData(IEnumerable<RecentQuota> recentQuotas)
        {
            var converter = new NOPInputConverter();
            var inputs = converter.ConvertInputs(recentQuotas);
            int halfCount = recentQuotas.Count() / 2;
            var trainData = inputs.Skip(halfCount).ToList();
            var testData = inputs.Take(halfCount).ToList();
            File.WriteAllText(@".\Datas\TrainData.json", trainData.Serialize());
            File.WriteAllText(@".\Datas\TestData.json", testData.Serialize());
        }
    }
}