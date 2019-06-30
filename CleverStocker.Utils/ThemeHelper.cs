using System;
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

        private static Themes currentTheme = Enum.TryParse(
            ConfigHelper.ReadConfig(ThemeConfigKey),
            out currentTheme) ?
            currentTheme : Themes.Dark;

        /// <summary>
        /// Gets or sets 当前主题类型
        /// </summary>
        public static Themes CurrentTheme
        {
            get => currentTheme;
            set
            {
                currentTheme = value;
                ConfigHelper.WriteConfig(ThemeConfigKey, value.ToString());
            }
        }

        /// <summary>
        /// Gets or sets 当前主题
        /// </summary>
        public static ThemeBase CurrentThemeComponent { get; set; }

        /// <summary>
        /// 获取停靠窗口背景色
        /// </summary>
        /// <returns></returns>
        public static Color GetDockFormBackcolor()
        {
            switch (CurrentTheme)
            {
                case Themes.Light:
                    return Color.FromArgb(255, 245, 245, 245);

                case Themes.Blue:
                    return Color.FromArgb(255, 247, 249, 254);

                case Themes.Dark:
                    return Color.FromArgb(255, 37, 37, 38);

                case Themes.Classics:
                default:
                    return Color.FromKnownColor(KnownColor.Control);
            }
        }
    }
}
