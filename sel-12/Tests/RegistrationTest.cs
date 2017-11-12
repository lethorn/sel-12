using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;

namespace sel_12.Tests
{
    [TestFixture]
    public class RegistrationTest : TestBase
    {
        [Test]
        public void UserRegistrationTest()
        {
            var randomUser = User.RandomizeUser();

            Driver.GoToUrl(UrlConstants.RootUrl);
            var mainPage = new MainPage();
            mainPage.EnsurePageLoaded();
            mainPage.UserRegistrationLink.Click();

            var registrationPage = new UserRegistrationPage();
            registrationPage.EnsurePageLoaded();
            registrationPage.RegisterUser(randomUser);
            
            mainPage.Logout();
            mainPage.Login(randomUser);
            mainPage.Logout();
        }
    }
}
