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
        
        private IWebElement buttonFlexible => Driver.FindElement(By.CssSelector("#site-content > div > div > div:nth-child(1) > div:nth-child(2) > div > div._jdvs9l4 > div > div._16xcv07v > div._kk9qp6 > a"));
        
        private IWebElement buttonBeachfront => Driver.FindElement(By.CssSelector("#filter-menu-chip-group > div:nth-child(2) > div > div._14an3y49 > div > div._alkx2 > div:nth-child(5) > button > div > div._j1kt73"));
        
        private IWebElement saveButton => Driver.FindElement(By.CssSelector("#filter-panel-save-button"));
        
        private IWebElement buttonAnytime => Driver.FindElement(By.CssSelector("#menuItemButton-stays_date_picker > button"));

        private IWebElement buttonWeekend => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-weekend_trip > button"));
        
        IReadOnlyCollection<IWebElement> BeachfrontResults => Driver.FindElements(By.CssSelector("#search-results-container > div > div > div > div > div:nth-child(3) > div > div > div > div._1e541ba5 > div > div > div._e296pg > div._3x2xkx > div > div._e296pg > div._1mx6kqf > div > span > div > a"));
        public Baigiamasis_projektas_AirbnbPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        
        public void ClickFlexibleButton(){
            buttonFlexible.Click();
        }
        
        public void ChooseBeachfrontOption(){
            buttonBeachfront.Click();
        }

        public void ClickButtonAnytime(){
            WaitForResult();
            buttonAnytime.Click();
        }
        
        public void ClickButtonSave(){
            saveButton.Click();
        }

        public void ClickButtonWeekend(){
            buttonWeekend.Click();
        }

        public void VerifyBeachfrontResults()
        {
            foreach (IWebElement beachfront in BeachfrontResults)
            {
                Assert.IsTrue(beachfront.GetAttribute("href").Contains("category_tag=Tag%3A789"), "Wrong result");
            }
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#search-results-container > div > div > div > div > div:nth-child(3) > div > div > div > div._1e541ba5 > div > div > div._e296pg > div._3x2xkx > div > div._e296pg > div._1mx6kqf > div > span > div > a"))
                    .Displayed);
        }
    }
}