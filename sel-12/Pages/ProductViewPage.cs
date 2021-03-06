﻿using System.Collections.Generic;
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
    public class ProductViewPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//h1[@itemprop = 'name']")]
        public readonly IWebElement ProductNameText;

        [FindsBy(How = How.ClassName, Using = "price-wrapper")]
        public readonly IWebElement ProductPriceContainer;

        [FindsBy(How = How.ClassName, Using = "images-wrapper")]
        public readonly IWebElement ProductStickersContainer;

        [FindsBy(How = How.Name, Using = "add_cart_product")]
        public readonly IWebElement AddToCartButton;

        [FindsBy(How = How.Id, Using = "cart")]
        public readonly IWebElement CartContainer;

        [FindsBy(How = How.XPath, Using = ".//a[normalize-space() = 'Checkout »']")]
        public readonly IWebElement CheckOutLink;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("box-product"));
        }

        public void AddProductToCart(int itemNumber)
        {
            var sizeSelect = Driver.Browser.FindElements(By.Name("options[Size]"));
            if (!sizeSelect.IsNullOrEmpty())
            {
                sizeSelect.First().SetSelectByText("Small");
            }
            AddToCartButton.Click();
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath($".//span[@class = 'quantity' and text() = '{itemNumber}']")));
        }

        public bool CheckActualPrice()
        {
            var actualPriceElement = ProductPriceContainer.FindElement(By.TagName("strong"));

            var actualPriceRgba = actualPriceElement.GetRgbaValues();
            var doesActualPriceRed = actualPriceRgba.Blue == 0 && actualPriceRgba.Green == 0;

            var actualPriceFontWeight = actualPriceElement.GetCssValue("font-weight");
            var doesActualPriceBold = actualPriceFontWeight.Equals("bold") || int.Parse(actualPriceFontWeight) >= 700;

            var oldPriceFontSize = ProductPriceContainer.FindElement(By.TagName("s")).GetFontSize();
            var actualPriceFontSize = actualPriceElement.GetFontSize();

            return doesActualPriceRed && doesActualPriceBold && actualPriceFontSize > oldPriceFontSize;
        }

        public bool CheckOldPrice()
        {
            var oldPriceElement = ProductPriceContainer.FindElement(By.TagName("s"));

            var oldPriceDecorations = oldPriceElement.GetCssValue("text-decoration").Split(' ');
            var doesOldPriceStriked = oldPriceDecorations.First().Equals("line-through");

            var oldPriceRgba = oldPriceElement.GetRgbaValues();
            var isOldPriceGrey = oldPriceRgba.Green == oldPriceRgba.Blue &&
                                 oldPriceRgba.Blue == oldPriceRgba.Red;

            return doesOldPriceStriked && isOldPriceGrey;
        }

        public Product GetProduct()
        {
            return new Product
            {
                ProductName = ProductNameText.Text,
                ActualPrice = GetActualPrice(),
                OldPrice = GetOldPrice(),
                Stickers = GetStickers()
            };
        }

        private List<string> GetStickers()
        {
            var stickers = ProductStickersContainer.FindElements(By.XPath(".//a/div"));
            return stickers.IsNullOrEmpty()
                ? new List<string>()
                : stickers.Select(x => x.Text).ToList();
        }

        private decimal GetActualPrice()
        {
            var isOnSale = !ProductPriceContainer.FindElements(By.TagName("s")).IsNullOrEmpty();
            var priceElementTag = isOnSale ? "strong" : "span";
            return decimal.Parse(ProductPriceContainer.FindElement(By.TagName(priceElementTag)).Text.Replace("$", string.Empty));
        }

        private decimal? GetOldPrice()
        {
            var isOnSale = !ProductPriceContainer.FindElements(By.TagName("s")).IsNullOrEmpty();
            return isOnSale
                ? decimal.Parse(ProductPriceContainer.FindElement(By.TagName("s")).Text.Replace("$", string.Empty))
                : (decimal?) null;
        }
    }
}
