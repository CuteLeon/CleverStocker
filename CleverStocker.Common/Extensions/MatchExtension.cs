using System.Text.RegularExpressions;

namespace CleverStocker.Common.Extensions
{
    /// <summary>
    /// Match 扩展
    /// </summary>
    public static class MatchExtension
    {
        /// <summary>
        /// 尝试获取匹配值
        /// </summary>
        /// <param name="match"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryGetValue(this Match match, string key, out string value)
        {
            Group group = match?.Groups[key];
            if (group == null || !group.Success)
            {
                value = null;
                return false;
            }

            value = group.Value;
            return true;
        }
    }
}
