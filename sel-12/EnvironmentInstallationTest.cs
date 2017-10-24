using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace sel_12
{
    [TestFixture]
    public class EnvironmentInstallationTest
    {
        private IWebDriver _driver;

        private WebDriverWait _wait;

        [FindsBy(How = How.XPath, Using = ".//input[@class = 'input__control input__input' and @aria-label = 'Запрос']")]
        public readonly IWebElement SearchQueryInput;

        [FindsBy(How = How.XPath, Using = ".//button[span[text() = 'Найти']]")]
        public readonly IWebElement SearchButton;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void EnvironmentTest()
        {
            _driver.Navigate().GoToUrl("http://www.yandex.ru");
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class = 'home-logo__default']")));
            SearchQueryInput.SendKeys("Hello World!");
            SearchButton.Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class = 'main__content']")));
        }
    }
}
