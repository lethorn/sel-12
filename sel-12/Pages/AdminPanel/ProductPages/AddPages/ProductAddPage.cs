using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
            var generalSection = new GeneralSection();
            generalSection.EnsurePageLoaded();
            generalSection.SetGeneralInfo(productToAdd);

            SaveButton.Click();
        }
    }
}
