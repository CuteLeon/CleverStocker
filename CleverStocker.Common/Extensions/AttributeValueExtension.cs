using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CleverStocker.Common.Extensions
{
    /// <summary>
    /// 特性数据扩展
    /// </summary>
    public static class AttributeValueExtension
    {
        /// <summary>
        /// 获取环境值
        /// </summary>
        /// <typeparam name="TValue">返回类型</typeparam>
        /// <param name="object"></param>
        /// <returns></returns>
        public static TValue GetAmbientValue<TValue>(this object @object)
        {
            FieldInfo fieldInfo = @object.GetType().GetField(@object.ToString());
            AmbientValueAttribute[] attributes = (AmbientValueAttribute[])fieldInfo.GetCustomAttributes(typeof(AmbientValueAttribute), false);
            return (attributes.Length > 0) ? (TValue)attributes[0].Value : default;
        }

        /// <summary>
        /// 获取显示名称
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDisplayName(this object value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DisplayAttribute[] attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Name.ToString() : string.Empty;
        }
    }
}
