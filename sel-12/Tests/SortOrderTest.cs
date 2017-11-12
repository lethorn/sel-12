using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages.AdminPanel;

namespace sel_12.Tests
{
    [TestFixture]
    public class SortOrderTest : TestBase
    {
        [Test]
        public void CountriesSortTest()
        {
            LoginAs(Users.Admin);

            var countriesPage = OpenCountriesManagementPage();
            var countries = countriesPage.GetCountries();
            CheckCountries(countries);

            var countriesWithZones = countries.Where(x => x.ZonesCount > 0);
            foreach (var country in countriesWithZones)
            {
                CheckCountries(GetCountryWithZones(country));
            }

        }

        [Test]
        public void GeoZonesSortTest()
        {
            LoginAs(Users.Admin);

            var countries = OpenGeoZonesManagementPage().GetCountries();
            countries.ForEach(x => OpenGeoZoneAndCheckSortingOrder(x.Name));
        }

        private static CountriesManagementPage OpenCountriesManagementPage()
        {
            Driver.GoToUrl(UrlConstants.CountriesPageUrl);
            var countriesPage = new CountriesManagementPage();
            countriesPage.EnsurePageLoaded();
            return countriesPage;
        }

        private static GeoZonesManagementPage OpenGeoZonesManagementPage()
        {
            Driver.GoToUrl(UrlConstants.GeoZonesUrl);
            var geoZonesPage = new GeoZonesManagementPage();
            geoZonesPage.EnsurePageLoaded();
            return geoZonesPage;
        }

        private void OpenGeoZoneAndCheckSortingOrder(string zoneName)
        {
            var zones  = OpenGeoZonesManagementPage()
                .OpenGeoZonePage(zoneName)
                .GetGeoZones();
            Assert.That(zones, Is.Ordered.By("ZoneName"));
        }

        private static IEnumerable<Country> GetCountryWithZones(Country country)
        {
            return OpenCountriesManagementPage()
                .OpenCountryEditPage(country.Name)
                .GetCountries();
        }

        private static void CheckCountries(IEnumerable<Country> countries)
        {
            Assert.That(countries, Is.Ordered.By("Name"));
        }
    }
}
