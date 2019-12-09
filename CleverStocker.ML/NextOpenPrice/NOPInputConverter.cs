using System.Collections.Generic;
using System.Linq;
using CleverStocker.Model;
using CleverStocker.Utils;

namespace CleverStocker.ML.NextOpenPrice
{
    /// <summary>
    /// NOP输入转换器
    /// </summary>
    public class NOPInputConverter : INOPInputConverter
    {
        /// <inheritdoc/>
        public IEnumerable<NOPInput> ConvertInputs(IEnumerable<RecentQuota> sources)
        {
            var inputs = sources
                .OrderByDescending(quota => quota.UpdateTime)
                .Select(source => this.ConvertInput(source))
                .ToList();

            inputs.Skip(1)
                .Select((input, index) =>
                {
                    input.NextOpenningPrice = inputs[index].OpenningPrice;
                    return input;
                })
                .Count();
            return inputs;
        }

        /// <inheritdoc/>
        public NOPInput ConvertInput(RecentQuota source)
            => AutoMapHelper.Map<NOPInput>(source);
    }
}
