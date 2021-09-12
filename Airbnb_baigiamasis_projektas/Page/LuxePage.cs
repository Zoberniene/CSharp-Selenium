using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Airbnb_baigiamasis_projektas.Page
{
    public class LuxePage: BasePage
    {
        private IWebElement locationInput => Driver.FindElement(By.CssSelector("#query"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#submit_btn"));
        private SelectElement adultsNum => new SelectElement(Driver.FindElement(By.Id("adults")));
        private SelectElement childrensNum => new SelectElement(Driver.FindElement(By.Id("children")));
      
        public LuxePage(IWebDriver webdriver) : base(webdriver) {}
        
        public void InsertDestination(string destination){
            WaitForResult();
            locationInput.Clear();
            locationInput.SendKeys(destination);
        }
        
        public void ClickSearchButton(){
            searchButton.Click();
        }

        public void SelectAdultsNum()
        {
            adultsNum.SelectByValue("4");
        }
        
        public void SelectChildrenNum()
        {
            childrensNum.SelectByValue("5");
        }
        
        private void WaitForResult()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#query"))
                    .Enabled);
        }
    }
    
}