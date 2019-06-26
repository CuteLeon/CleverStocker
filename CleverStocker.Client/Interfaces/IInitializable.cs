using System.Collections.Generic;

namespace CleverStocker.Client.Interfaces
{
    /// <summary>
    /// 可初始化接口
    /// </summary>
    public interface IInitializable
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> Initialize();
    }
}
