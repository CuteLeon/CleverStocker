using System;
using Microsoft.ML.AutoML;
using Microsoft.ML.Data;

namespace CleverStocker.MLTests
{
    public class RegressionExperimentProgressHandler : IProgress<RunDetail<RegressionMetrics>>
    {
        private int index;

        public void Report(RunDetail<RegressionMetrics> iterationResult)
        {
            this.index++;
            Console.WriteLine($"报告编号：{this.index}\t训练器名称：{iterationResult.TrainerName}\t训练时长：{iterationResult.RuntimeInSeconds}");
        }
    }
}
