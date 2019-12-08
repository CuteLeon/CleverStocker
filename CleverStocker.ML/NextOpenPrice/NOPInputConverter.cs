using System.Collections.Generic;
using System.Linq;
using CleverStocker.Model;

namespace CleverStocker.ML.NextOpenPrice
{
    /// <summary>
    /// NOP输入转换器
    /// </summary>
    public class NOPInputConverter : IInputConverter<RecentQuota, NOPInput>
    {
        /// <inheritdoc/>
        public IEnumerable<NOPInput> ConvertInputs(IEnumerable<RecentQuota> sources)
        {
            // TODO: 赋值下次开盘价格
            return sources.Select(source => this.ConvertInput(source));
        }

        /// <inheritdoc/>
        public NOPInput ConvertInput(RecentQuota source)
        {
            // TODO: 赋值输入模型
            return default;
        }
    }
}
