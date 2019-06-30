using System;
using System.Drawing;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Utils.Tests
{
    [TestClass()]
    public class ThemeHelperTests
    {
        [TestMethod()]
        public void ThemeHelperUnitTest()
        {
            foreach (var theme in new ThemeBase[] {
                new VS2015DarkTheme(),
                new VS2015BlueTheme(),
                new VS2015LightTheme(),
            })
            {
                string themeName = theme.GetType().Name;
                Console.WriteLine("——————————————");
                Console.WriteLine($"/* 主题名称：{themeName} */");
                Color color;

                foreach (var property in theme.ColorPalette.GetType().GetProperties())
                {

                    if (property.PropertyType.Name == "Color")
                    {
                        color = (Color)property.GetValue(theme.ColorPalette);
                        Console.WriteLine($"{themeName}.{property.Name} {{ color: rgba({color.R}, {color.G}, {color.B}, 1.0); }}");
                    }
                    else
                    {
                        Console.WriteLine($"{themeName}.{property.Name} {{");

                        var value = property?.GetValue(theme.ColorPalette);
                        var type = value?.GetType();
                        var propertys = type?.GetProperties();
                        if (propertys != null)
                        {
                            foreach (var colorProperty in property?.GetValue(theme.ColorPalette)?.GetType()?.GetProperties()
                                .Where(p => p.PropertyType.Name == "Color"))
                            {
                                color = (Color)colorProperty.GetValue(value);
                                Console.WriteLine($"\t{colorProperty.Name}: rgba({color.R}, {color.G}, {color.B}, 1.0);");
                            }
                        }

                        Console.WriteLine("}");
                    }
                }
            }
        }
    }
}