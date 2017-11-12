using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel.ProductPages.AddPages
{
    public class GeneralSection : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//label[normalize-space() = 'Enabled']/input")]
        public readonly IWebElement EnabledRadioButton;

        [FindsBy(How = How.Name, Using = "name[en]")]
        public readonly IWebElement ProductNameInput;

        [FindsBy(How = How.Name, Using = "code")]
        public readonly IWebElement ProductCodeInput;

        [FindsBy(How = How.XPath, Using = ".//input[@type = 'file']")]
        public readonly IWebElement UploadFileInput;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Name("name[en]"));
        }

        public void SetGeneralInfo(Product product)
        {
            EnabledRadioButton.Click();
            ProductNameInput.SendKeys(product.ProductName);
            ProductCodeInput.SendKeys(product.Code);
            UploadFileInput.SendKeys(product.ImagePath);
        }
    }
}
