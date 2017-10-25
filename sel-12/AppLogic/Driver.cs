using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace sel_12.AppLogic
{
    /// <summary>
    /// Хелпер для взаимодействия с WebDriver
    /// </summary>
    public static class Driver
    {
        private static IWebDriver _browser;

        private static WebDriverWait _browserWait;


        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("WebDriver instance wasn't initialized");
                }
                return _browser;
            }
            set => _browser = value;
        }
        
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browser == null || _browserWait == null)
                {
                    throw new NullReferenceException("WebDriver browser wait instance wasn't initialized");
                }
                return _browserWait;
            }
            set => _browserWait = value;
        }

        /// <summary>
        /// Инициализирует WebDriver для конкретного типа браузера, задает таймаут для ожидания драйвера
        /// </summary>
        /// <param name="browserType">Тип браузера</param>
        /// <param name="defaultWaitTimeOut">Таймаут ожиданий браузера (в секундах)</param>
        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultWaitTimeOut = 10)
        {
            switch (browserType)
            {
                case BrowserTypes.Chrome:
                    Browser = new ChromeDriver();
                    break;
                case BrowserTypes.Firefox:
                    Browser = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultWaitTimeOut));
        }

        /// <summary>
        /// Останавливает WebDriver
        /// </summary>
        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }

        public static void GoToUrl(string url)
        {
            Browser.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Типы браузеров
        /// </summary>
        public enum BrowserTypes
        {
            // update if needed
            Chrome,
            Firefox
        }
    }
}
