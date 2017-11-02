using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;
using sel_12.Pages.AdminPanel;

namespace sel_12.Tests
{
    public abstract class TestBase
    {

        [OneTimeSetUp]
        public void SetUp()
        {
            Driver.StartBrowser();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }

        protected AdminPage LoginAs(User userCredentials)
        {
            Driver.GoToUrl(UrlConstants.AdminPageUrl);

            var loginPage = new LoginPage();
            loginPage.EnsurePageLoaded();
            loginPage.SetAccountInfo(userCredentials);

            var adminPage = new AdminPage();
            adminPage.EnsurePageLoaded();
            return adminPage;
        }
    }
}
