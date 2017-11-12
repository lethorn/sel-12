using System.Collections.Generic;
using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace sel_12.Utils
{
    public static class WebElementUtils
    {
        public struct RgbColors
        {
            public int Red;
            public int Green;
            public int Blue;
        }

        public static RgbColors GetRgbaValues(this IWebElement element)
        {
            var rawRgbaValue = element.GetCssValue("color")
                .Replace("rgba(", string.Empty)
                .Replace(");", string.Empty)
                .Split(',');
            return new RgbColors
            {
                Red = int.Parse(rawRgbaValue[0]),
                Green = int.Parse(rawRgbaValue[1]),
                Blue = int.Parse(rawRgbaValue[2])
            };
        }

        public static decimal GetFontSize(this IWebElement element)
        {
            return decimal.Parse(element.GetCssValue("font-size").Replace("px", string.Empty), CultureInfo.InvariantCulture);
        }

        public static void SetSelectByText(this IWebElement element, string text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }
    }
}
