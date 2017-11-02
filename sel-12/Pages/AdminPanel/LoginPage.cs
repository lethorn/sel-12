using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Models;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    /// <summary>
    /// Класс, описывающий страницу авторизации
    /// </summary>
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "username")]
        public readonly IWebElement UsernameInput;

        [FindsBy(How = How.Name, Using = "password")]
        public readonly IWebElement PasswordInput;

        [FindsBy(How = How.Name, Using = "login")]
        public readonly IWebElement LoginButton;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Name("login_form"));
        }

        public void SetAccountInfo(User credentials)
        {
            UsernameInput.SendKeys(credentials.UserName);
            PasswordInput.SendKeys(credentials.Password);
            LoginButton.Click();
        }
    }
}
