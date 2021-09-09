using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace testing1.Page
{
    public class AirbnbExperiencesPage: BasePage
    {
        private IWebElement filters => Driver.FindElement(By.CssSelector("#menuItemButton-dynamicMoreFilters > button"));
        
        private IWebElement priceMin => Driver.FindElement(By.CssSelector("#price_filter_min"));
        private IWebElement priceMax => Driver.FindElement(By.CssSelector("#price_filter_max"));
        private IWebElement price1 => Driver.FindElement(By.CssSelector("#ExploreLayoutController > div:nth-child(2) > div:nth-child(1) > div._twmmpk > div > div:nth-child(1) > div > div > div > div:nth-child(2) > div > div > div > div._e296pg > div > div > div > div:nth-child(3) > div > div > div > div > div._1g2tewe5 > div._1gartvrn > span > span > span"));
        
        private IWebElement showResultsButton => Driver.FindElement(By.CssSelector("body > div:nth-child(23) > section > div > div > div._z4lmgp > div > footer > button"));
        
        IReadOnlyCollection<IWebElement> prices => Driver.FindElements(By.CssSelector("#ExploreLayoutController > div:nth-child(2) > div:nth-child(1) > div._twmmpk > div > div:nth-child(1) > div > div > div > div:nth-child(2) > div > div > div > div._e296pg > div > div > div > div > div > div > div > div > div._1g2tewe5 > div._1gartvrn > span > span > span"));
        public AirbnbExperiencesPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ChooseFilters(){
            filters.Click();
        }
        
        public void InsertPriceRange(){
            priceMin.Clear();
            priceMin.SendKeys("20");
            priceMax.Clear();
            priceMax.SendKeys("30");
        }
        
        public void ShowFilteredResults(){
            showResultsButton.Click();
        }
        
        public void VerifyFilteredPriceResults()
        {
            foreach (IWebElement price in prices)
            {
                string digitPrice = price.Text.Substring(8, 2);
                int numPrice = int.Parse(digitPrice);
                Assert.IsTrue(numPrice > 20 && numPrice < 30, "Price filter doesn't work");
            }
        }
    }
}