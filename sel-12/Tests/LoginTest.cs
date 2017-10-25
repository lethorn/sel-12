using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;

namespace sel_12.Tests
{
    [TestFixture]
    public class UserLoginTest : TestBase
    {
        private static readonly TestCaseData[] LoginCases =
        {
            new TestCaseData(new User("admin", "12345")).SetName("{m} - Admin account")
        };

        [TestCaseSource(nameof(LoginCases))]
        public void LoginTest(User userCredentials)
        {
            Driver.GoToUrl(UrlConstants.AdminPageUrl);

            var loginPage = new LoginPage();
            loginPage.EnsurePageLoaded();
            loginPage.SetAccountInfo(userCredentials);

            var adminPage = new AdminPage();
            adminPage.EnsurePageLoaded();

            Assert.True(adminPage.LogoImage.Displayed);
        }
    }
}
