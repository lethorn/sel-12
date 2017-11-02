using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.CommonTestEntities;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;

namespace sel_12.Tests
{
    [TestFixture]
    public class MainPageTest : TestBase
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
            CheckProductsByCategory(Product.ProductCategories.Campaings, 
                expectedProducts.Where(x => x.StickerValue.Equals("SALE")));
            CheckProductsByCategory(Product.ProductCategories.Latest, expectedProducts);
        }

        private void CheckProductsByCategory(Product.ProductCategories productCategory, IEnumerable<Product> expectedInfo)
        {
            var actualProducts = new MainPage().GetProductsByCategory(productCategory);
            Assert.That(actualProducts, Is.EquivalentTo(expectedInfo));
        }
    }
}
