using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class GeoZonesManagementPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "dataTable")]
        public IWebElement GeoZonesTable;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h1[normalize-space() = 'Geo Zones']"));
        }

        public GeoZoneEditPage OpenGeoZonePage(string zoneName)
        {
            GeoZonesTable.FindElement(By.XPath($".//a[text() = '{zoneName}']")).Click();
            var zoneEditPage = new GeoZoneEditPage();
            zoneEditPage.EnsurePageLoaded();
            return zoneEditPage;
        }

        public List<Country> GetCountries()
        {
            return GetTableRows().Select(GetCountry).ToList();
        }

        private static Country GetCountry(IWebElement tableRow)
        {
            var countryInfo = tableRow.FindElements(By.TagName("td"));
            return new Country
            {
                Id = int.Parse(countryInfo[1].Text),
                Name = countryInfo[2].Text,
                ZonesCount = int.Parse(countryInfo[3].Text)
            };
        }

        private IEnumerable<IWebElement> GetTableRows()
        {
            return GeoZonesTable.FindElements(By.XPath(".//tbody/tr[@class = 'row']"));
        }
    }
}
