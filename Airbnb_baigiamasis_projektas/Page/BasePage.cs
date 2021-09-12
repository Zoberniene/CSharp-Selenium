using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class BasePage
    {
        protected IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public WebDriverWait GetWait(int seconds = 7)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

    }
}