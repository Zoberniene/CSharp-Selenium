using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class AirbnbFexiblePage: BasePage
    {
        private IWebElement beachfrontTab => Driver.FindElement(By.CssSelector("#filter-menu-chip-group > div:nth-child(2) > div > div._14an3y49 > div > div._alkx2 > div:nth-child(7)"));
        
        private IWebElement saveButton => Driver.FindElement(By.CssSelector("#filter-panel-save-button"));
        
        private IWebElement anytimeButton => Driver.FindElement(By.CssSelector("#menuItemButton-stays_date_picker > button"));

        private IWebElement weekendButton => Driver.FindElement(By.CssSelector("#flexible_trip_lengths-weekend_trip > button"));
        
        IReadOnlyCollection<IWebElement> beachfrontResults => Driver.FindElements(By.CssSelector("#search-results-container > div > div > div > div > div:nth-child(3) > div > div > div > div._1e541ba5 > div > div > div._e296pg > div._3x2xkx > div > div._e296pg > div._1mx6kqf > div > span > div > a"));

        IReadOnlyCollection<IWebElement> weekendHouses => Driver.FindElements(By.CssSelector("#search-results-container > div > div > div > div > div:nth-child(3) > div > div > div > div._1e541ba5 > div > div > div._e296pg > div._3x2xkx > div > div._e296pg > div._1mx6kqf > div > span > div > a"));
        
        public AirbnbFexiblePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ChooseBeachfrontOption(){
            beachfrontTab.Click();
        }

        public void ClickButtonAnytime(){
            anytimeButton.Click();
        }
        
        public void ClickButtonSave(){
            saveButton.Click();
        }

        public void ClickButtonWeekend(){
            weekendButton.Click();
        }

        public void VerifyBeachfrontResults()
        {
            WaitForResult();
            foreach (IWebElement beachfront in beachfrontResults)
            {
                Assert.IsTrue(beachfront.GetAttribute("href").Contains("category_tag=Tag%3A789"), "Wrong result");
            }
            
        }
        
        public void VerifyWeekendResults()
        {
            foreach (IWebElement house in weekendHouses)
            {
                string checkIn = house.GetAttribute("href").Substring(101, 10);
                string checkOut = house.GetAttribute("href").Substring(122, 10);
                DateTime in1 = Convert.ToDateTime(checkIn);
                DateTime out2 = Convert.ToDateTime(checkOut);
                TimeSpan diff = out2 - in1;
                string daysDiff = diff.ToString();
                Assert.AreEqual('2', daysDiff[0], "Wrong date difference");
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