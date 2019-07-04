using System;
using System.Linq;
using System.Windows.Forms;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 调用助手
    /// </summary>
    public static class InvokeHelper
    {
        /// <summary>
        /// 在控件上同步调用
        /// </summary>
        /// <typeparam name="TReturn">返回类型</typeparam>
        /// <typeparam name="TDelegate">委托签名</typeparam>
        /// <param name="control"></param>
        /// <param name="delegate"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks>传参时，频繁传入值类型，会因为与 object 的装箱拆箱而导致性能问题</remarks>
        public static TReturn InvokeIfRequired<TReturn, TDelegate>(this Control control, TDelegate @delegate, params object[] @params)
            where TDelegate : Delegate
        {
            if (@delegate == null ||
                @delegate.Method == null)
            {
                throw new ArgumentNullException(nameof(@delegate));
            }

            var tReturn = typeof(TReturn);
            var dReturn = @delegate.Method.ReturnType;
            if (dReturn != tReturn &&
                !dReturn.IsSubclassOf(tReturn))
            {
                throw new ArgumentException($"{nameof(TReturn)}泛型返回值类型 {tReturn.Name} 与委托返回值类型 {dReturn.Name} 不匹配");
            }

            var args = @delegate.Method.GetParameters();
            int maxLength = args.Length;
            int minLength = args.Count(p => !p.IsOptional);
            if (@params.Length < minLength ||
                @params.Length > maxLength)
            {
                throw new ArgumentException($"传入的实际参数数量({args.Length}) 与 委托的形式参数数量({minLength}~{maxLength}) 不匹配");
            }

            try
            {
                if (control == null || !control.InvokeRequired)
                {
                    return (TReturn)@delegate.DynamicInvoke(@params);
                }
                else
                {
                    return (TReturn)control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params)));
                }
            }
            catch (Exception ex)
            {
                LogHelper<Delegate>.ErrorException(ex, "执行 Invoke 委托失败：");
                throw;
            }
        }

        /// <summary>
        /// 在控件上同步调用
        /// </summary>
        /// <param name="control"></param>
        /// <param name="delegate"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        /// <remarks>传参时，频繁传入值类型，会因为与 object 的装箱拆箱而导致性能问题</remarks>
        public static object InvokeIfRequired(this Control control, Delegate @delegate, params object[] @params)
        {
            try
            {
                if (control == null || !control.InvokeRequired)
                {
                    return @delegate.DynamicInvoke(@params);
                }
                else
                {
                    return control?.Invoke(new Func<object>(() => @delegate.DynamicInvoke(@params)));
                }
            }
            catch (Exception ex)
            {
                LogHelper<Delegate>.ErrorException(ex, "执行 Invoke 委托失败：");
                throw;
            }
        }
    }
}
