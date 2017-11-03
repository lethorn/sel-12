using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;

namespace sel_12.Tests
{
    [TestFixture]
    public class SidebarLinksTest : TestBase
    {
        [Test]
        public void SidebarNavigationTest()
        {
            LoginAs(Users.Admin);

            var linksCount = Driver.Browser.FindElements(By.Id("app-")).Count;
            for (var i = 1; i <= linksCount; i++)
            {
                Driver.Browser.FindElement(By.XPath($".//li[{i}][@id = 'app-']/a")).Click();
                CheckHeaderAvailability();
                var subLinksCount = Driver.Browser.FindElements(By.XPath(".//ul[@class = 'docs']/li")).Count;
                if (subLinksCount > 1)
                {
                    for (var j = 2; j <= subLinksCount; j++)
                    {
                        Driver.Browser.FindElement(By.XPath($".//ul[@class = 'docs']/li[{j}]/a")).Click();
                        CheckHeaderAvailability();
                    }
                }
            }
        }

        private static void CheckHeaderAvailability()
        {
            var doesHeaderExists = Driver.Browser.FindElements(By.TagName("h1")).Any(x => x.Displayed);
            Assert.True(doesHeaderExists);
        }
    }
}
