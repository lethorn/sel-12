using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.AppLogic;

namespace sel_12.Tests
{
    public abstract class TestBase
    {

        [SetUp]
        public void SetUp()
        {
            Driver.StartBrowser();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.StopBrowser();
        }
    }
}
