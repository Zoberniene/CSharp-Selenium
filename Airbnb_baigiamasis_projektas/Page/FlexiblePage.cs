using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class FlexiblePage: BasePage
    {
        private IWebElement saveButton => Driver.FindElement(By.CssSelector("#filter-panel-save-button"));
        private IWebElement anytimeButton => Driver.FindElement(By.CssSelector("#menuItemButton-stays_date_picker > button"));
        private IWebElement weekendButton => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-weekend_trip > button"));
        private IWebElement filters => Driver.FindElement(By.CssSelector("._fva31s > button"));
        private IWebElement priceMin => Driver.FindElement(By.CssSelector("#price_filter_min"));
        private IWebElement priceMax => Driver.FindElement(By.CssSelector("#price_filter_max"));
        private IWebElement showStays => Driver.FindElement(By.CssSelector("body > div > section > div > div > div._z4lmgp > div > footer > button"));
        IReadOnlyCollection<IWebElement> weekendResults => Driver.FindElements(By.CssSelector("#search-results-container ._1e541ba5 ._e296pg ._3x2xkx ._e296pg ._1mx6kqf a"));
        IReadOnlyCollection<IWebElement> prices => Driver.FindElements(By.CssSelector("#search-results-container > div > div > div > div > div:nth-child(3) > div > div > div > div._1e541ba5 ._e296pg ._1qfyimw > div > div > div > span"));
        public FlexiblePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ClickAnytimeButton(){
            anytimeButton.Click();
        }
        
        public void ClickSaveButton(){
            saveButton.Click();
        }

        public void ClickWeekendButton(){
            weekendButton.Click();
        }

        public void VerifyWeekendResults()
        {
            foreach (IWebElement weekendHouse in weekendResults)
            {
                string checkIn = weekendHouse.GetAttribute("href").Substring(101, 10);
                string checkOut = weekendHouse.GetAttribute("href").Substring(122, 10);
                DateTime check_in = Convert.ToDateTime(checkIn);
                DateTime check_out = Convert.ToDateTime(checkOut);
                TimeSpan diff = check_out - check_in;
                string daysDiff = diff.ToString();
                Assert.AreEqual('2', daysDiff[0], "Wrong days difference");
            }
        }
        
        public void ClickOnFilters(){
            filters.Click();
        }
        
        public void InsertPriceRange(){
            priceMin.Clear();
            priceMin.SendKeys("1000");
            priceMax.Clear();
            priceMax.SendKeys("1200");
            showStays.Click();
        }
        
        public void VerifyFilteredPriceResults()
        {
            foreach (IWebElement price in prices)
            {
                string digitPrice = price.Text.Substring(1, 5);
                int numPrice = int.Parse(digitPrice.Replace(",", ""));
                Assert.IsTrue(numPrice > 1000, "Price filter doesn't work");
            }
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#search-results-container ._3x2xkx ._e296pg ._1mx6kqf a"))
                    .Displayed);
        }
    }
}