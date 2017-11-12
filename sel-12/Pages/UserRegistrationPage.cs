using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using sel_12.AppLogic;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages
{
    public class UserRegistrationPage : BasePage
    {
        #region WebElements

        [FindsBy(How = How.Name, Using = "tax_id")]
        public readonly IWebElement TaxIdInput;

        [FindsBy(How = How.Name, Using = "company")]
        public readonly IWebElement CompanyInput;

        [FindsBy(How = How.Name, Using = "firstname")]
        public readonly IWebElement FirstNameInput;

        [FindsBy(How = How.Name, Using = "lastname")]
        public readonly IWebElement LastNameInput;

        [FindsBy(How = How.Name, Using = "address1")]
        public readonly IWebElement MainAddressInput;

        [FindsBy(How = How.Name, Using = "address2")]
        public readonly IWebElement AdditionalAddressInput;

        [FindsBy(How = How.Name, Using = "postcode")]
        public readonly IWebElement PostcodeInput;

        [FindsBy(How = How.Name, Using = "city")]
        public readonly IWebElement CityInput;

        [FindsBy(How = How.Name, Using = "country_code")]
        public readonly IWebElement CountrySelect;

        [FindsBy(How = How.Name, Using = "email")]
        public readonly IWebElement EmailInput;

        [FindsBy(How = How.Name, Using = "phone")]
        public readonly IWebElement PhoneInput;

        [FindsBy(How = How.Name, Using = "newsletter")]
        public readonly IWebElement SubscribeCheckBox;

        [FindsBy(How = How.Name, Using = "password")]
        public readonly IWebElement DesiredPasswordInput;

        [FindsBy(How = How.Name, Using = "confirmed_password")]
        public readonly IWebElement ConfirmPasswordInput;

        [FindsBy(How = How.Name, Using = "create_account")]
        public readonly IWebElement CreateAccountButton;

        #endregion

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Name("create_account"));
        }

        public void RegisterUser(User user)
        {
            TaxIdInput.SendKeys(user.TaxId);
            CompanyInput.SendKeys(user.Company);
            FirstNameInput.SendKeys(user.FirstName);
            LastNameInput.SendKeys(user.LastName);
            MainAddressInput.SendKeys(user.MainAddress);
            AdditionalAddressInput.SendKeys(user.AdditionalAddress);
            PostcodeInput.SendKeys(user.PostCode);
            CityInput.SendKeys(user.City);
            CountrySelect.SendKeys(user.Country);
            EmailInput.SendKeys(user.Email);
            PhoneInput.SendKeys(user.Phone);
            if (user.SubscribedToNewsletter)
            {
                SubscribeCheckBox.Click();
            }
            DesiredPasswordInput.SendKeys(user.Password);
            ConfirmPasswordInput.SendKeys(user.Password);
            CreateAccountButton.Click();
            Driver.BrowserWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//a[normalize-space() = 'Logout']")));
        }
    }
}
