using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace sel_12.Utils
{
    public static class ExpectedConditionsExtensions
    {
        public static Func<IWebDriver, string> AnyWindowOtherThan(ReadOnlyCollection<string> oldWindows)
        {
            return driver =>
            {
                var handles = driver.WindowHandles.Except(oldWindows).ToList();
                return handles.Any() ? handles.First() : null;
            } ;
        }
    }
}
