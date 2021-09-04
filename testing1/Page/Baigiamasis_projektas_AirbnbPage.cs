using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Baigiamasis_projektas_AirbnbPage: BasePage
    {
        private const string AddressUrl = "https://www.airbnb.com/";
        
        private IWebElement flexibleButton => Driver.FindElement(By.CssSelector("#site-content > div > div > div:nth-child(1) > div:nth-child(2) > div > div._jdvs9l4 > div > div._16xcv07v > div._kk9qp6 > a"));
        private IWebElement locationInput => Driver.FindElement(By.CssSelector("#bigsearch-query-detached-query-input"));
        
        public Baigiamasis_projektas_AirbnbPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        
        public void ClickFlexibleButton(){
            flexibleButton.Click();
        }
    }
}