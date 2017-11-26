using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.AdminPanel.ProductPages.AddPages;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    public class CatalogPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[normalize-space() = 'Add New Product']")]
        public readonly IWebElement AddProductButton;

        [FindsBy(How = How.XPath, Using = ".//table[@class = 'dataTable']/tbody/tr[@class = 'row' and not(td[3][i[contains(@class, 'fa-folder')]])]")]
        public readonly IList<IWebElement> CatalogTableRows;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h1[normalize-space() = 'Catalog']"));
        }

        public List<string> GetCatalogElementsNames()
        {
            return CatalogTableRows.Select(x => x.FindElement(By.XPath("./td[3]//a")).Text)
                .ToList();
        }

        public void AddProdict(Product productToAdd)
        {
            AddProductButton.Click();
            var addPage = new ProductAddPage();
            addPage.EnsurePageLoaded();
            addPage.AddProduct(productToAdd);
        }
    }
}
