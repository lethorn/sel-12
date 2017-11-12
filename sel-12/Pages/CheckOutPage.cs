using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using sel_12.AppLogic;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages
{
    public class CheckOutPage : BasePage
    {
        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("checkout-cart-wrapper"));
        }

        public void RemoveProduct(Product product)
        {
            var productRow = Driver.Browser.FindElements(By.XPath($".//tr/td[@class = 'item' and normalize-space() = '{product.ProductName}']")).FirstOrDefault();
            Driver.BrowserWait.Until(ExpectedConditions.ElementToBeClickable(By.Name("remove_cart_item"))).Click();
            Driver.BrowserWait.Until(ExpectedConditions.StalenessOf(productRow));
        }
    }
}
