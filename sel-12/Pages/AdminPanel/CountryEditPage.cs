using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class CountryEditPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "table-zones")]
        public readonly IWebElement ZonesTable;

        [FindsBy(How = How.XPath, Using = ".//a[i[@class = 'fa fa-external-link']]")]
        public readonly IList<IWebElement> ExternalLinks;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("body"));
        }

        public List<Country> GetCountries()
        {
            return ZonesTable.FindElements(By.XPath(".//tbody/tr[not(@class = 'header') and not(td[button])]"))
                .Select(GetCountry)
                .ToList();
        }

        private static Country GetCountry(IWebElement tableRow)
        {
            var countryInfo = tableRow.FindElements(By.TagName("td"));
            return new Country
            {
                Id = int.Parse(countryInfo[0].Text),
                Code = countryInfo[1].Text,
                Name = countryInfo[2].Text
            };
        }
    }
}
