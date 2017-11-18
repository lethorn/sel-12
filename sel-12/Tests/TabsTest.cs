using NUnit.Framework;
using OpenQA.Selenium;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;
using sel_12.Constants;
using sel_12.Pages.AdminPanel;
using sel_12.Utils;

namespace sel_12.Tests
{
    [TestFixture]
    public class TabsTest : TestBase
    {
        [Test]
        public void TabsOpeningTest()
        {
            LoginAs(Users.Admin);
            Driver.GoToUrl(UrlConstants.CountriesPageUrl);
            var countryEditPage = new CountriesManagementPage().OpenCountryEditPage("Austria");
            countryEditPage.EnsurePageLoaded();
            foreach (var externalLink in countryEditPage.ExternalLinks)
            {
                OpenNewTabAndCheckContent(externalLink);
            }
        }

        private static void OpenNewTabAndCheckContent(IWebElement link)
        {
            var originalWindowHandles = Driver.Browser.WindowHandles;
            var originalWindowHandle = Driver.Browser.CurrentWindowHandle;
            var originalWindowTitle = Driver.Browser.Title;
            link.Click();
            var newHandle = Driver.BrowserWait.Until(ExpectedConditionsExtensions.AnyWindowOtherThan(originalWindowHandles));
            var newTitle = Driver.Browser.Title;
            Driver.Browser.SwitchTo().Window(newHandle);
            Assert.That(newTitle, Is.Not.EqualTo(originalWindowTitle));
            Driver.Browser.Close();
            Driver.Browser.SwitchTo().Window(originalWindowHandle);
        }
    }
}
