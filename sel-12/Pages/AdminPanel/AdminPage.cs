using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using sel_12.Pages.Base;

namespace sel_12.Pages.AdminPanel
{
    /// <summary>
    /// Класс, описывающий страницу панели администрирования
    /// </summary>
    public class AdminPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//div[@class = 'logotype']/a/img")]
        public readonly IWebElement LogoImage;

        public override void EnsurePageLoaded()
        {
            EnsureElementExists(By.Id("content"));
        }
    }
}
