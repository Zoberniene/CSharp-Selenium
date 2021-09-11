using NUnit.Framework;
using OpenQA.Selenium;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class SearchResultsPage: BasePage
    {
        private IWebElement priceButton => Driver.FindElement(By.CssSelector("#menuItemButton-price_range > button"));
        private IWebElement averagePrice => Driver.FindElement(By.CssSelector("._1b6av9s"));
        public SearchResultsPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void ClickPriceButton(){
            priceButton.Click();
        }
        
        public void VerifyAveragePriceResults()
        {
            Assert.AreEqual("The average nightly price is €101", averagePrice.Text, "Wrong average price result");
        }
    }
}