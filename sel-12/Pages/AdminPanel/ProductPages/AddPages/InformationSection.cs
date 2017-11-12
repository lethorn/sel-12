using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;
using sel_12.Utils;

namespace sel_12.Pages.AdminPanel.ProductPages.AddPages
{
    public class InformationSection : BasePage
    {
        [FindsBy(How = How.Name, Using = "manufacturer_id")]
        public readonly IWebElement ManufacturerSelect;

        [FindsBy(How = How.Name, Using = "short_description[en]")]
        public readonly IWebElement ShortDescriptionInput;

        [FindsBy(How = How.Name, Using = "description[en]")]
        public readonly IWebElement DescriptionTextArea;

        [FindsBy(How = How.Name, Using = "head_title[en]")]
        public readonly IWebElement HeadTitleInput;

        [FindsBy(How = How.Name, Using = "meta_description[en]")]
        public readonly IWebElement MetaDescriptionInput;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Name("manufacturer_id"));
        }

        public void SetProductInformation(Product product)
        {
            ManufacturerSelect.SetSelectByText(product.Manufacturer);
            ShortDescriptionInput.SendKeys(product.ShortDescription);
            DescriptionTextArea.SendKeys(product.Description);
            HeadTitleInput.SendKeys(product.HeadTitle);
            MetaDescriptionInput.SendKeys(product.MetaDescription);
        }
    }
}
