using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automation_practice_BA.Page
{
    public class HomePage: BasePage
    {
        private const string AddressUrl = "http://automationpractice.com/index.php";
        private IWebElement searchInput => Driver.FindElement(By.CssSelector("#search_query_top"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#searchbox > button"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector("#center_column > ul > li"));
        private IWebElement searchResultsHeading => Driver.FindElement(By.CssSelector("#center_column > h1 > span.lighter"));
        private IWebElement itemAddedToCart => Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2"));
        private IWebElement itemNumInCart => Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > h2 > span.ajax_cart_product_txt"));
        private IWebElement proceedToCartButton => Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
        IReadOnlyCollection<IWebElement> searchResults => Driver.FindElements(By.CssSelector("#center_column > ul > li > div > div.right-block > h5 > a"));
        public HomePage(IWebDriver webdriver) : base(webdriver) {}

        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        
        public void InsertSearchProductName(string name){
            searchInput.Clear();
            searchInput.SendKeys(name);
        }
        
        public void ClickSearchButton(){
            searchButton.Click();
        }
        
        public void VerifySearchResults()
        {
            Assert.IsTrue(searchResultsHeading.Text.Contains("PRINTED"), "Wrong search result heading");
            foreach (IWebElement result in searchResults)
            {
                Assert.IsTrue(result.Text.Contains("Printed"), "Wrong search results");
            }
        }
        
        public void AddItemToCart(){
            IWebElement firstResultElement = results.ElementAt(0);
            Actions action = new Actions(Driver);
            IWebElement imageElement = firstResultElement.FindElement(By.CssSelector("#center_column > ul > li.ajax_block_product.col-xs-12.col-sm-6.col-md-4.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line > div > div.left-block > div > a.product_img_link > img"));
            action.MoveToElement(imageElement);
            action.Build().Perform();
            firstResultElement.FindElement(By.XPath("//span[contains(.,'Add to cart')]")).Click();
        }
        
        public void VerifyIfItemWasAddedToCart()
        {
            WaitForResult();
            Assert.AreEqual("Product successfully added to your shopping cart", itemAddedToCart.Text, "Wrong success message");
            Assert.AreEqual("There is 1 item in your cart.", itemNumInCart.Text, "Wrong number of items in the cart");
        }
        
        public void ProceedToCart()
        {
            proceedToCartButton.Click();
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_product.col-xs-12.col-md-6 > h2"))
                    .Displayed);
        }
        
    }
}