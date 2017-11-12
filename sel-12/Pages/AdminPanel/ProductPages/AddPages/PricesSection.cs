using System.Globalization;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;
using sel_12.Utils;

namespace sel_12.Pages.AdminPanel.ProductPages.AddPages
{
    public class PricesSection : BasePage
    {
        [FindsBy(How = How.Name, Using = "purchase_price")]
        public readonly IWebElement PurchasePriceInput;

        [FindsBy(How = How.Name, Using = "purchase_price_currency_code")]
        public readonly IWebElement PurchasePriceCurrencySelect;

        [FindsBy(How = How.Name, Using = "prices[USD]")]
        public readonly IWebElement PriceUsdInput;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.XPath(".//h2[normalize-space() = 'Prices']"));
        }

        public void SetPrices(Product product)
        {
            PurchasePriceInput.SendKeys(product.ActualPrice.ToString(CultureInfo.InvariantCulture));
            PurchasePriceCurrencySelect.SetSelectByText(product.CurrencyCode);
            PriceUsdInput.SendKeys(product.ActualPrice.ToString(CultureInfo.InvariantCulture));
        }
    }
}
