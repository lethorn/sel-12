using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class CountriesManagementPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "dataTable")]
        public readonly IWebElement CountriesTable;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.ClassName("dataTable"));
        }

        public List<Country> GetCountries()
        {
            return CountriesTable.FindElements(By.XPath(".//tbody/tr[not(@class = 'header') and not(@class = 'footer')]"))
                .Select(GetCountry)
                .ToList();
        }

        public CountryEditPage OpenCountryEditPage(string countryName)
        {
            CountriesTable.FindElement(By.XPath($".//a[text() = '{countryName}']")).Click();
            var countryEditPage = new CountryEditPage();
            countryEditPage.EnsurePageLoaded();
            return countryEditPage;
        }

        private static Country GetCountry(IWebElement tableRow)
        {
            var countryInfo = tableRow.FindElements(By.TagName("td"));
            return new Country
            {
                Id = int.Parse(countryInfo[2].Text),
                Code = countryInfo[3].Text,
                Name = countryInfo[4].Text,
                ZonesCount = int.Parse(countryInfo[5].Text)
            };
        }
    }
}
