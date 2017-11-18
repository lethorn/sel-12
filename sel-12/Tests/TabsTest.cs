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

        private void OpenNewTabAndCheckContent(IWebElement link)
        {
            var originalWindowHandles = Driver.Browser.WindowHandles;
            var originalWindowTitle = Driver.Browser.Title;
            var originalWindowHandle = Driver.Browser.CurrentWindowHandle;
            link.Click();
            var newHandle = Driver.BrowserWait.Until(ExpectedConditionsExtensions.AnyWindowOtherThan(originalWindowHandles));
            Driver.Browser.SwitchTo().Window(newHandle);
            Assert.That(Driver.Browser.Title, Is.Not.EqualTo(originalWindowTitle));
            Driver.Browser.Close();
            Driver.Browser.SwitchTo().Window(originalWindowHandle);
        }
    }
}
