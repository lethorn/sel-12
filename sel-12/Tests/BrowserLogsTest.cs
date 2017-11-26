using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;
using sel_12.Constants;
using sel_12.Pages.AdminPanel;

namespace sel_12.Tests
{
    [TestFixture]
    public class BrowserLogsTest : TestBase
    {
        private const string JqMigrateMessage = "JQMIGRATE: Migrate is installed, version 1.4.1";

        [Test]
        public void LogsTest()
        {
            LoginAs(Users.Admin);
            Driver.GoToUrl(UrlConstants.CatalogsUrl);
            OpenProductPageAndCheckLogs();
        }

        public void OpenProductPageAndCheckLogs()
        {
            var catalogPage = new CatalogPage();
            catalogPage.EnsurePageLoaded();
            var productNames = catalogPage.GetCatalogElementsNames();

            foreach (var productName in productNames)
            {
                Driver.Browser.FindElement(By.XPath($".//td[3]//a[text() = '{productName}']")).Click();
                var logs = new List<LogEntry>();
                logs.AddRange(Driver.Browser.Manage().Logs.GetLog(LogType.Browser));
                // Если требуется успешное выполнение теста - убираем сообщение о миграции
                //logs.RemoveAll(x => x.Message.Contains(JqMigrateMessage));
                Assert.That(logs, Is.Empty);
                Driver.Browser.Navigate().Back();
                catalogPage.EnsurePageLoaded();
            }
        }
    }
}
