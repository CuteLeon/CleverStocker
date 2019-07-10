using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 序列化助手
    /// </summary>
    /// <remarks>序列化 System.Data.Entity.DynamicProxies 相关类型异常时，需要使用克隆助手克隆后再尝试序列化</remarks>
    public static class SerializerHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Serialize<T>(this T source)
            where T : class, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        serializer.Serialize(writer, source);
                        return Encoding.UTF8.GetString(stream.GetBuffer());
                    }
                }
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="content">内容</param>
        /// <returns>对象</returns>
        public static T Deserialize<T>(this string content)
            where T : class, new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        return serializer.Deserialize(reader) as T;
                    }
                }
            }
            catch
            {
                return default;
            }
        }
    }
}
