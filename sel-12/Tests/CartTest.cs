using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using sel_12.AppLogic;
using sel_12.Constants;
using sel_12.Models;
using sel_12.Pages;

namespace sel_12.Tests
{
    [TestFixture]
    public class CartTest : TestBase
    {
        [Test]
        public void CartFillTest()
        {
            var products = new List<Product>();
            for (var itemNumber = 0; itemNumber <= 2; itemNumber++)
            {
                AddProductToCart(itemNumber + 1, out Product product);
                products.Add(product);
            }

            OpenCart();
            products.Reverse();
            products.ForEach(RemoveProductFromCart);
        }

        private static void AddProductToCart(int itemNumber, out Product addedProduct)
        {
            Driver.GoToUrl(UrlConstants.RootUrl);
            var mainPage = new MainPage();
            mainPage.EnsurePageLoaded();
            addedProduct = mainPage.GetProduct(mainPage.MostPopularProductsElements.First());
            mainPage.OpenProductViewPage(addedProduct, Product.ProductCategories.MostPopular);
            var productViewPage = new ProductViewPage();
            productViewPage.EnsurePageLoaded();
            productViewPage.AddProductToCart(itemNumber);
        }

        private static void OpenCart()
        {
            var productViewPage = new ProductViewPage();
            productViewPage.EnsurePageLoaded();
            productViewPage.CheckOutLink.Click();
        }

        private static void RemoveProductFromCart(Product product)
        {
            var checkoutPage = new CheckOutPage();
            checkoutPage.EnsurePageLoaded();
            checkoutPage.RemoveProduct(product);
        }
    }
}
