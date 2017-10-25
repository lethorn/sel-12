using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using sel_12.AppLogic;

namespace sel_12.Tests
{
    [TestFixture]
    public class EnvironmentInstallationTest : TestBase
    {
        [FindsBy(How = How.XPath, Using = ".//input[@class = 'input__control input__input' and @aria-label = 'Запрос']")]
        public readonly IWebElement SearchQueryInput;

        [FindsBy(How = How.XPath, Using = ".//button[span[text() = 'Найти']]")]
        public readonly IWebElement SearchButton;

        [Test]
        public void EnvironmentTest()
        {
            Driver.GoToUrl("http://www.yandex.ru");
            PageFactory.InitElements(Driver.Browser, this);
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class = 'home-logo__default']")));
            SearchQueryInput.SendKeys("Hello World!");
            SearchButton.Click();
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class = 'main__content']")));
        }
    }
}
