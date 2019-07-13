using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Utils
{
    /// <summary>
    /// 主题助手
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// 主题配置键
        /// </summary>
        private const string ThemeConfigKey = "Theme";

        static ThemeHelper()
        {
            CurrentTheme = ConverterHelper.StringToEnum(
                ConfigHelper.ReadConfig(ThemeConfigKey),
                Themes.Dark);

            CurrentThemeComponent = GetTheme(CurrentTheme);
        }

        /// <summary>
        /// Gets 当前主题类型
        /// </summary>
        public static Themes CurrentTheme { get; }

        /// <summary>
        /// Gets 当前主题
        /// </summary>
        public static ThemeBase CurrentThemeComponent { get; }

        /// <summary>
        /// 获取主题组件
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static ThemeBase GetTheme(Themes theme)
        {
            switch (theme)
            {
                case Themes.Dark:
                    return new VS2015DarkTheme();

                case Themes.Blue:
                    return new VS2015BlueTheme();

                case Themes.Light:
                    return new VS2015LightTheme();

                default:
                    return new VS2015DarkTheme();
            }
        }

        /// <summary>
        /// 保存下次使用的主题
        /// </summary>
        /// <param name="theme"></param>
        public static void SaveNextTheme(Themes theme)
            => ConfigHelper.WriteConfig(ThemeConfigKey, theme.ToString());

        /// <summary>
        /// 获取容器背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetContainerBackcolor()
            => CurrentThemeComponent.ColorPalette.ToolWindowTabSelectedActive.Background;

        /// <summary>
        /// 获取内容颜色
        /// </summary>
        /// <returns></returns>
        public static Color GetContentForecolor()
            => CurrentThemeComponent.ColorPalette.CommandBarMenuDefault.Text;

        /// <summary>
        /// 获取内容高亮背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetContentHighLightBackcolor()
            => CurrentThemeComponent.ColorPalette.ToolWindowBorder;

        /// <summary>
        /// 获取内容高亮色
        /// </summary>
        /// <returns></returns>
        public static Color GetContentHighLightForecolor()
            => CurrentThemeComponent.ColorPalette.ToolWindowCaptionInactive.Text;

        /// <summary>
        /// 获取标题背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetTitleBackcolor()
            => CurrentThemeComponent.ColorPalette.CommandBarToolbarDefault.Background;

        /// <summary>
        /// 获取标题色
        /// </summary>
        /// <returns></returns>
        public static Color GetTitleForecolor()
            => CurrentThemeComponent.ColorPalette.CommandBarToolbarDefault.OverflowButtonGlyph;

        /// <summary>
        /// 获取行情前景颜色
        /// </summary>
        /// <param name="quota"></param>
        /// <returns></returns>
        public static Color GetQuotaForecolor(double quota)
            => quota >= 0.0 ? Color.Crimson : Color.LimeGreen;
    }
}
