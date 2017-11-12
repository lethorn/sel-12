using NUnit.Framework;
using OpenQA.Selenium;
using sel_12.AppLogic;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages.AdminPanel;
using sel_12.Utils;

namespace sel_12.Tests
{
    public abstract class TestBase
    {

        [OneTimeSetUp]
        public virtual void SetUp()
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
            if (!Driver.Browser.FindElements(By.Name("login_form")).IsNullOrEmpty())
            {
                var loginPage = new LoginPage();
                loginPage.EnsurePageLoaded();
                loginPage.SetAccountInfo(userCredentials);
            }

            var adminPage = new AdminPage();
            adminPage.EnsurePageLoaded();
            return adminPage;
        }
    }
}
