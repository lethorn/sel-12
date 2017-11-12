using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.AppLogic;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel.ProductPages.AddPages
{
    public class ProductAddPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//button[normalize-space() = 'Save']")]
        public readonly IWebElement SaveButton;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h1[normalize-space() = 'Add New Product']"));
        }

        public void AddProduct(Product productToAdd)
        {
            SetGeneralInfo(productToAdd);
            SetInformation(productToAdd);
            SetPrices(productToAdd);
            SaveButton.Click();
        }

        private void SetGeneralInfo(Product product)
        {
            var generalSection = new GeneralSection();
            generalSection.EnsurePageLoaded();
            generalSection.SetGeneralInfo(product);
        }

        private void SetInformation(Product product)
        {
            OpenSection(ProductAddPageSections.Information);
            var informationSection = new InformationSection();
            informationSection.EnsurePageLoaded();
            informationSection.SetProductInformation(product);
        }

        private void SetPrices(Product product)
        {
            OpenSection(ProductAddPageSections.Prices);
            var pricesSection = new PricesSection();
            pricesSection.EnsurePageLoaded();
            pricesSection.SetPrices(product);
        }

        public void OpenSection(ProductAddPageSections section)
        {
            string sectionText;
            switch (section)
            {
                case ProductAddPageSections.General:
                    sectionText = "General";
                    break;
                case ProductAddPageSections.Information:
                    sectionText = "Information";
                    break;
                case ProductAddPageSections.Prices:
                    sectionText = "Prices";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(section), section, null);
            }
            var sectionLinkPath = $".//ul[@class = 'index']/li/a[text() = '{sectionText}']";
            Driver.Browser.FindElement(By.XPath(sectionLinkPath)).Click();
        }

        // update if needed
        public enum ProductAddPageSections
        {
            General,
            Information,
            Prices
        }
    }
}
