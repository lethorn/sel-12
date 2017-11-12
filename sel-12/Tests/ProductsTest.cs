using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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

        [TestCaseSource(nameof(StickersCases))]
        public void StickersTest(List<Product> expectedProducts)
        {
            Driver.GoToUrl(UrlConstants.RootUrl);

            var mainPage = new MainPage();
            mainPage.EnsurePageLoaded();
            
            CheckProductsByCategory(Product.ProductCategories.MostPopular, expectedProducts);
            CheckProductsByCategory(Product.ProductCategories.Campaigns, 
                expectedProducts.Where(x => x.Stickers.Contains("SALE")));
            CheckProductsByCategory(Product.ProductCategories.Latest, expectedProducts);
        }

        [Test]
        public void ProductsEqualityTest()
        {
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
        }

        [Test]
        public void ProductAddTest()
        {
            var newProduct = new Product
            {
                Code = "123",
                ProductName = "12345",
                ImagePath = FileConsts.DataDirectoryPath + "\\duck.jpg"
            };

            LoginAs(Users.Admin);
            Driver.GoToUrl(UrlConstants.CatalogsUrl);
            var catalogsPage = new CatalogPage();
            catalogsPage.EnsurePageLoaded();
            catalogsPage.AddProductButton.Click();

            var addPage = new ProductAddPage();
            addPage.EnsurePageLoaded();
            addPage.AddProduct(newProduct);
        }

        private static void CheckProductsByCategory(Product.ProductCategories productCategory, IEnumerable<Product> expectedInfo)
        {
            var actualProducts = new MainPage().GetProductsByCategory(productCategory);
            Assert.That(actualProducts, Is.EquivalentTo(expectedInfo));
        }
    }
}
