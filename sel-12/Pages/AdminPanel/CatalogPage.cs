using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class CatalogPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[normalize-space() = 'Add New Product']")]
        public readonly IWebElement AddProductButton;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h1[normalize-space() = 'Catalog']"));
        }
    }
}
