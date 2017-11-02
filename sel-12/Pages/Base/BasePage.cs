﻿using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using sel_12.AppLogic;

namespace sel_12.Pages.Base
{
    public abstract class BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//li[@id = 'app-']/a")]
        public IList<IWebElement> SidebarLinks;

        public abstract void EnsurePageLoaded();

        protected BasePage()
        {
            PageFactory.InitElements(Driver.Browser, this);
        }

        public void EnsureElementExists(By uniqueLocator)
        {
            Driver.BrowserWait.Until(ExpectedConditions.ElementExists(uniqueLocator));
        }
    }
}
