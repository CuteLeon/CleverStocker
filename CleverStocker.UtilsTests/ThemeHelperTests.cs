using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            ThemeBase[] themes = new ThemeBase[] {
                new VS2015DarkTheme(),
                new VS2015BlueTheme(),
                new VS2015LightTheme(),
            };
            ThemeBase firstTheme = themes[0];
            Color color;

            foreach (var property in firstTheme.ColorPalette.GetType().GetProperties().OrderBy(p => p.Name))
            {
                if (property.PropertyType.Name == "Color")
                {
                    Console.WriteLine($"{property.Name} {{");
                    foreach (var theme in themes)
                    {
                        color = (Color)property.GetValue(theme.ColorPalette);
                        Console.WriteLine($"\t{theme.GetType().Name}: rgba({color.R}, {color.G}, {color.B}, 1.0);");
                    }
                    Console.WriteLine("}");
                }
                else
                {
                    Console.WriteLine($"{property.Name} {{");

                    foreach (var childProperty in property.PropertyType?
                        .GetProperties()?.Where(p => p.PropertyType.Name == "Color") ??
                        Enumerable.Empty<PropertyInfo>())
                    {
                        foreach (var theme in themes)
                        {
                            try
                            {
                                var value = property.GetValue(theme.ColorPalette);
                                if (value != null)
                                {
                                    color = (Color)childProperty.GetValue(value);
                                    Console.WriteLine($"\t{theme.GetType().Name}-{childProperty.Name}: rgba({color.R}, {color.G}, {color.B}, 1.0);");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{theme.GetType().Name}-{childProperty.Name} 错误：{ex.Message}");
                            }
                        }

                        Console.WriteLine("");
                    }

                    Console.WriteLine("}");
                }
            }
        }
    }
}