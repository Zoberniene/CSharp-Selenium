using NUnit.Framework;
using OpenQA.Selenium;

namespace testing1.Page
{
    public class AirbnbSearchResultsPage: BasePage
    {
        private IWebElement priceButton => Driver.FindElement(By.CssSelector("#menuItemButton-price_range > button"));
        
        private IWebElement averagePrice => Driver.FindElement(By.CssSelector("#filter-menu-chip-group > div._3lctk2 > div > div:nth-child(3) > div > div:nth-child(3) > div > div._1oo3nqe > div > div > div > div > div._1b6av9s"));
        public AirbnbSearchResultsPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ClickPriceButton(){
            priceButton.Click();
        }
        
        public void VerifyAveragePriceResults()
        {
            Assert.AreEqual("The average nightly price is €101", averagePrice.Text, "Wrong average price result");
           
            
        }
    }
}