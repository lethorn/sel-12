using NUnit.Framework;
using sel_12.CommonTestEntities;
using sel_12.Models;

namespace sel_12.Tests
{
    [TestFixture]
    public class UserLoginTest : TestBase
    {
        private static readonly TestCaseData[] LoginCases =
        {
            new TestCaseData(Users.Admin).SetName("{m} - Admin account")
        };

        [TestCaseSource(nameof(LoginCases))]
        public void LoginTest(User userCredentials)
        {
            var adminPage = LoginAs(userCredentials);
            Assert.True(adminPage.LogoImage.Displayed);
        }
    }
}
