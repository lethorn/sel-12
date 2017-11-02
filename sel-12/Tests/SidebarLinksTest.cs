using System;
using System.Collections.Generic;
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
        private static readonly TestCaseData[] SidebarLinks =
        {
            new TestCaseData(CommonTestEntities.SidebarLinks.AllLinks).SetName("{m}") 
        };

        [TestCaseSource(nameof(SidebarLinks))]
        public void SidebarNavigationTest(List<Tuple<string, List<string>>> linkNames)
        {
            LoginAs(Users.Admin);
            // NOTE: Наименования ссылок заданы статично, чтобы обрабатывать ситуации, 
            // когда на странице пропали нужные ссылки или отображаются некорректные наименования
            linkNames.ForEach(link =>
            {
                // Проверяем родительскую ссылку
                OpenLinkAndCheckHeader(link.Item1);
                // Проверяем дочерние ссылки (если имеются)
                link.Item2.ForEach(OpenLinkAndCheckHeader);
            });
        }

        private static void OpenLinkAndCheckHeader(string linkName)
        {
            Driver.Browser.FindElement(By.XPath($".//a[span[text() = '{linkName}']]")).Click();
            var doesHeaderExists = Driver.Browser.FindElements(By.TagName("h1"))
                .Any(x => x.Displayed);
            Assert.True(doesHeaderExists);
        }
    }
}
