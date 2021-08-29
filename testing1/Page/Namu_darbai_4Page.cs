using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Namu_darbai_4Page: BasePage
    {
        private SelectElement multiDropdown => new SelectElement(Driver.FindElement(By.Id("cars")));
        
        private IWebElement submitButton => Driver.FindElement(By.XPath("/html/body/form/input"));
        //private IWebElement submitButton => Driver.FindElement(By.CssSelector("body > form > input[type=submit]"));

        private IWebElement result => Driver.FindElement(By.XPath("/html/body/div[1]"));
        
        public Namu_darbai_4Page(IWebDriver webdriver) : base(webdriver) {}
        
        public void AcceptCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.Id("accept-choices"))
                    .Displayed); 
            Driver.FindElement(By.Id("accept-choices")).Click();
        }
        public void ClickSubmitButton()
        {
            /*WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d =>
                d.FindElement(By.CssSelector("body > form > input[type=submit]"))
                    .Displayed); 
            Driver.FindElement(By.CssSelector("body > form > input[type=submit]")).Click();*/
            submitButton.Click();
        }
        
        
        
    }
}