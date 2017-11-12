using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.AppLogic;
using sel_12.Models;
using sel_12.Pages.Base;
using sel_12.Utils;

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
                case Product.ProductCategories.Campaigns:
                    return CampaignProductsElements.Select(GetProduct).ToList();
                case Product.ProductCategories.Latest:
                    return LatestProductsElements.Select(GetProduct).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        private Product GetProduct(IWebElement productContainer)
        {
            var stickers = GetStickers(productContainer);
            var isOnSale = stickers.Contains("SALE");

            return new Product
            {
                ProductName = productContainer.FindElement(By.ClassName("name")).Text,
                Manufacturer = productContainer.FindElement(By.ClassName("manufacturer")).Text,
                Price = GetProductPrice(productContainer, isOnSale),
                Stickers = stickers
            };
        }

        private static decimal GetProductPrice(ISearchContext productContainer, bool isOnSale)
        {
            var className = isOnSale ? "campaign-price" : "price";
            return decimal.Parse(productContainer.FindElement(By.ClassName(className))
                .Text
                .Replace("$", String.Empty));
        }

        private List<string> GetStickers(IWebElement productElement)
        {
            var stickers = productElement.FindElements(By.XPath(".//div[@class = 'image-wrapper']/div"));
            return stickers.IsNullOrEmpty() 
                ? new List<string>() 
                : stickers.Select(x => x.Text).ToList();
        }
    }
}
