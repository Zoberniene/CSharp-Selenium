using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation_practice_BA.Page
{
    public class BasePage
    {
        protected IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
    }
}