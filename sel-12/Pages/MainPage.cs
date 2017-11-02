using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//div[@id = 'box-most-popular']/div/ul/li")]
        public readonly IList<IWebElement> MostPopularProductsElements;

        [FindsBy(How = How.XPath, Using = ".//div[@id = 'box-campaigns']/div/ul/li")]
        public readonly IList<IWebElement> CampaignProductsElements;

        [FindsBy(How = How.XPath, Using = ".//div[@id = 'box-latest-products']/div/ul/li")]
        public readonly IList<IWebElement> LatestProductsElements;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("slider-wrapper"));
        }

        public List<Product> GetProductsByCategory(Product.ProductCategories category)
        {
            switch (category)
            {
                case Product.ProductCategories.MostPopular:
                    return MostPopularProductsElements.Select(GetProduct).ToList();
                case Product.ProductCategories.Campaings:
                    return CampaignProductsElements.Select(GetProduct).ToList();
                case Product.ProductCategories.Latest:
                    return LatestProductsElements.Select(GetProduct).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        private Product GetProduct(IWebElement productContainer)
        {
            // Стикер должен быть единственным для конкретного товара
            var stickerElement = productContainer.FindElements(By.XPath(".//div[contains(@class, 'sticker')]")).Single();
            var isOnSale = stickerElement.GetAttribute("class").Equals("sticker sale");

            return new Product
            {
                ProductName = productContainer.FindElement(By.ClassName("name")).Text,
                Manufacturer = productContainer.FindElement(By.ClassName("manufacturer")).Text,
                Price = GetProductPrice(productContainer, isOnSale),
                StickerValue = stickerElement.Text
            };
        }

        private decimal GetProductPrice(ISearchContext productContainer, bool isOnSale)
        {
            var className = isOnSale ? "campaign-price" : "price";
            return decimal.Parse(productContainer.FindElement(By.ClassName(className))
                .Text
                .Replace("$", String.Empty));
        }
    }
}
