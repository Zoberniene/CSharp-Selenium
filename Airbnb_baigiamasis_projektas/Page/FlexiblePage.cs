using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class FlexiblePage: BasePage
    {
        private IWebElement beachfrontTab => Driver.FindElement(By.CssSelector("._alkx2 > div:nth-child(7)"));
        private IWebElement saveButton => Driver.FindElement(By.CssSelector("#filter-panel-save-button"));
        private IWebElement anytimeButton => Driver.FindElement(By.CssSelector("#menuItemButton-stays_date_picker > button"));
        private IWebElement weekendButton => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-weekend_trip > button"));
        private IWebElement filters => Driver.FindElement(By.CssSelector("._fva31s > button"));
        private IWebElement priceMin => Driver.FindElement(By.CssSelector("#price_filter_min"));
        private IWebElement priceMax => Driver.FindElement(By.CssSelector("#price_filter_max"));
        private IWebElement showStays => Driver.FindElement(By.CssSelector("body > div > section > div > div > div._z4lmgp > div > footer > button"));
        IReadOnlyCollection<IWebElement> beachfrontResults => Driver.FindElements(By.CssSelector("#search-results-container ._3x2xkx ._e296pg ._1mx6kqf a"));
        IReadOnlyCollection<IWebElement> weekendResults => Driver.FindElements(By.CssSelector("#search-results-container ._1e541ba5 ._e296pg ._3x2xkx ._e296pg ._1mx6kqf a"));
        
        public FlexiblePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ChooseBeachfrontOption(){
            beachfrontTab.Click();
        }
        
        public void VerifyBeachfrontResults()
        {
            WaitForResult();
            foreach (IWebElement beachfront in beachfrontResults)
            {
                Assert.IsTrue(beachfront.GetAttribute("href").Contains("category_tag=Tag%3A789"), "Wrong beachfront category result");
            }
            
        }

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
            priceMin.SendKeys("100");
            priceMax.Clear();
            priceMax.SendKeys("150");
           // Thread.Sleep(5000);
            //showStays.Click();
        }
        
        /*public void VerifyFilteredPriceResults()
        {
        //patikrinti ir stiliu, kad atsiranda filtro zenkliukas
            foreach (IWebElement price in prices)
            {
                string digitPrice = price.Text.Substring(8, 2);
                int numPrice = int.Parse(digitPrice);
                Assert.IsTrue(numPrice > 20 && numPrice < 30, "Price filter doesn't work");
            }
        }*/
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#search-results-container ._3x2xkx ._e296pg ._1mx6kqf a"))
                    .Displayed);
        }
    }
}