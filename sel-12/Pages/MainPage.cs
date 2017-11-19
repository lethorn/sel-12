using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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

        [FindsBy(How = How.CssSelector, Using = "li.product")]
        public readonly IList<IWebElement> ProductElements;

        [FindsBy(How = How.Name, Using = "email")]
        public readonly IWebElement UserEmailInput;

        [FindsBy(How = How.Name, Using = "password")]
        public readonly IWebElement UserPasswordInput;

        [FindsBy(How = How.XPath, Using = ".//button[normalize-space() = 'Login']")]
        public readonly IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = ".//a[normalize-space() = 'New customers click here']")]
        public readonly IWebElement UserRegistrationLink;

        [FindsBy(How = How.XPath, Using = ".//a[normalize-space() = 'Logout']")]
        public readonly IWebElement LogoutLink;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("slider-wrapper"));
        }

        public void Login(User user)
        {
            UserEmailInput.SendKeys(user.Email);
            UserPasswordInput.SendKeys(user.Password);
            LoginButton.Click();
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//a[normalize-space() = 'Logout']")));
        }

        public void Logout()
        {
            LogoutLink.Click();
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//a[normalize-space() = 'New customers click here']")));
        }

        public int GetProductStickersCount(IWebElement productElement)
        {
            return productElement.FindElements(By.CssSelector("div.sticker")).Count;
        }

        public bool CheckOldPrice(IWebElement productContainer)
        {
            var priceContainer = productContainer.FindElement(By.ClassName("price-wrapper"));
            var oldPriceElement = priceContainer.FindElement(By.TagName("s"));

            var oldPriceDecorations = oldPriceElement.GetCssValue("text-decoration").Split(' ');
            var doesOldPriceStriked = oldPriceDecorations.First().Equals("line-through");

            var oldPriceRgba = oldPriceElement.GetRgbaValues();
            var isOldPriceGrey = oldPriceRgba.Green == oldPriceRgba.Blue && 
                oldPriceRgba.Blue == oldPriceRgba.Red;

            return doesOldPriceStriked && isOldPriceGrey;
        }

        public bool CheckActualPrice(IWebElement productContainer)
        {
            var priceContainer = productContainer.FindElement(By.ClassName("price-wrapper"));
            var actualPriceElement = priceContainer.FindElement(By.TagName("strong"));

            var actualPriceRgba = actualPriceElement.GetRgbaValues();
            var doesActualPriceRed = actualPriceRgba.Blue == 0 && actualPriceRgba.Green == 0;

            var actualPriceFontWeight = actualPriceElement.GetCssValue("font-weight");
            var doesActualPriceBold = actualPriceFontWeight.Equals("bold") || int.Parse(actualPriceFontWeight) >= 700;

            var oldPriceFontSize = priceContainer.FindElement(By.TagName("s")).GetFontSize();
            var actualPriceFontSize = actualPriceElement.GetFontSize();

            return doesActualPriceRed && doesActualPriceBold && actualPriceFontSize > oldPriceFontSize;
        }

        public void OpenProductViewPage(Product product, Product.ProductCategories category)
        {
            switch (category)
            {
                case Product.ProductCategories.MostPopular:
                    MostPopularProductsElements.Select(x => GetProductLink(x, product.ProductName))
                        .First()
                        .Click();
                    break;
                case Product.ProductCategories.Campaigns:
                    CampaignProductsElements.Select(x => GetProductLink(x, product.ProductName))
                        .First()
                        .Click();
                    break;
                case Product.ProductCategories.Latest:
                    LatestProductsElements.Select(x => GetProductLink(x, product.ProductName))
                        .First()
                        .Click();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
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

        public Product GetProduct(IWebElement productContainer)
        {
            var stickers = GetStickers(productContainer);
            var isOnSale = stickers.Contains("SALE");
            var priceContainer = productContainer.FindElement(By.ClassName("price-wrapper"));

            return new Product
            {
                ProductName = productContainer.FindElement(By.ClassName("name")).Text,
                Manufacturer = productContainer.FindElement(By.ClassName("manufacturer")).Text,
                ActualPrice = GetActualPrice(priceContainer, isOnSale),
                OldPrice = isOnSale ? GetOldPrice(priceContainer) : null,
                Stickers = stickers
            };
        }

        private static decimal GetActualPrice(ISearchContext priceContainer, bool isOnSale)
        {
            var tagName = isOnSale ? "strong" : "span";
            return decimal.Parse(priceContainer.FindElement(By.TagName(tagName))
                .Text
                .Replace("$", string.Empty));
        }

        private static decimal? GetOldPrice(ISearchContext priceContainer)
        {
            return decimal.Parse(priceContainer.FindElement(By.TagName("s"))
                .Text
                .Replace("$", string.Empty));
        }

        private static List<string> GetStickers(IWebElement productElement)
        {
            var stickers = productElement.FindElements(By.XPath(".//div[@class = 'image-wrapper']/div"));
            return stickers.IsNullOrEmpty() 
                ? new List<string>() 
                : stickers.Select(x => x.Text).ToList();
        }

        private static IWebElement GetProductLink(IWebElement productElement, string productName)
        {
            return productElement.FindElement(By.XPath($".//a[@title = '{productName}']"));
        }
    }
}
