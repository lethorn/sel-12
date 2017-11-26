using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;
using sel_12.Pages.AdminPanel;
using sel_12.Pages.AdminPanel.ProductPages.AddPages;

namespace sel_12.Tests
{
    [TestFixture]
    public class ProductsTest : TestBase
    {
        private static readonly TestCaseData[] StickersCases =
        {
            new TestCaseData(Products.AllProducts).SetName("{m}")
        };

        private static readonly TestCaseData[] ProductAddCases =
        {
            new TestCaseData(Products.ProductToAdd).SetName("{m}") 
        };

        private static readonly TestCaseData[] DriverCases =
        {
            new TestCaseData(Driver.BrowserTypes.Chrome).SetName("{m} - Chrome"),
            new TestCaseData(Driver.BrowserTypes.Firefox).SetName("{m} - Firefox"),
            new TestCaseData(Driver.BrowserTypes.InternetExplorer).SetName("{m} - IE"),
        };

        public override void SetUp()
        {
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            TearDown();
        }

        [TestCaseSource(nameof(StickersCases))]
        public void StickersTest(List<Product> expectedProducts)
        {
            Driver.StartBrowser();
            Driver.GoToUrl(UrlConstants.RootUrl);

            var mainPage = new MainPage();
            mainPage.EnsurePageLoaded();

            foreach (var productElement in mainPage.ProductElements)
            {
                CheckThatProductHasOneSticker(productElement);
            }
        }

        [TestCaseSource(nameof(DriverCases))]
        public void ProductsEqualityTest(Driver.BrowserTypes browserType)
        {
            Driver.StartBrowser(browserType);
            Driver.GoToUrl(UrlConstants.RootUrl);

            var mainPage = new MainPage();
            mainPage.EnsurePageLoaded();

            var firstCampaignProduct = mainPage.GetProduct(mainPage.CampaignProductsElements.First());

            Assert.True(mainPage.CheckOldPrice(mainPage.CampaignProductsElements.First()));
            Assert.True(mainPage.CheckActualPrice(mainPage.CampaignProductsElements.First()));

            mainPage.OpenProductViewPage(firstCampaignProduct, Product.ProductCategories.Campaigns);
            var productViewPage = new ProductViewPage();
            productViewPage.EnsurePageLoaded();

            var actualProduct = productViewPage.GetProduct();
            Assert.That(actualProduct, Is.EqualTo(firstCampaignProduct));
            Assert.True(productViewPage.CheckOldPrice());
            Assert.True(productViewPage.CheckActualPrice());
        }

        [TestCaseSource(nameof(ProductAddCases))]
        public void ProductAddTest(Product productToAdd)
        {
            Driver.StartBrowser();
            LoginAs(Users.Admin);
            OpenCatalogPage().AddProdict(productToAdd);
            CheckProductAfterAddition(productToAdd);
        }

        private static CatalogPage OpenCatalogPage()
        {
            Driver.GoToUrl(UrlConstants.CatalogsUrl);
            var catalogsPage = new CatalogPage();
            catalogsPage.EnsurePageLoaded();
            return catalogsPage;
        }

        private static void CheckProductAfterAddition(Product expectedProduct)
        {
            var catalogsPage = OpenCatalogPage();
            var catalogItems = catalogsPage.GetCatalogElementsNames();
            Assert.That(catalogItems, Does.Contain(expectedProduct.ProductName));
        }

        private static void CheckThatProductHasOneSticker(IWebElement productElement)
        {
            var mainPage = new MainPage();
            var stickersCount = mainPage.GetProductStickersCount(productElement);
            Assert.That(stickersCount, Is.EqualTo(1));
        }
    }
}
