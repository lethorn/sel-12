using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class GeoZoneEditPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "table-zones")]
        public readonly IWebElement GeoZonesTable;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h1[normalize-space() = 'Edit Geo Zone']"));
        }

        public List<GeoZone> GetGeoZones()
        {
            return GetTableRows().Select(GetGeoZone).ToList();
        }

        private static GeoZone GetGeoZone(IWebElement tableRow)
        {
            var zoneInfo = tableRow.FindElements(By.TagName("td"));
            return new GeoZone
            {
                Id = int.Parse(zoneInfo[0].Text),
                Country = GetSelectValue(zoneInfo[1].FindElement(By.TagName("select"))),
                ZoneName = GetSelectValue(zoneInfo[2].FindElement(By.TagName("select")))
            };
        }

        private static string GetSelectValue(IWebElement selectElement)
        {
            return selectElement.FindElement(By.XPath(".//option[@selected = 'selected']")).Text;
        }

        private IEnumerable<IWebElement> GetTableRows()
        {
            return GeoZonesTable.FindElements(By.XPath(".//tbody/tr[not(@class = 'header') and not(td[a[@id = 'add_zone']])]"));
        }
    }
}
