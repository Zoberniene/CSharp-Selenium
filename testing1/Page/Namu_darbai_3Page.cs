using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Namu_darbai_3Page : BasePage
    {
       
        private IWebElement input1 => Driver.FindElement(By.Id("sum1"));
        private IWebElement input2 => Driver.FindElement(By.Id("sum2"));
        private IWebElement sumButton => Driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement result => Driver.FindElement(By.Id("displayvalue"));
        public Namu_darbai_3Page(IWebDriver webdriver) : base(webdriver) {}


        public void ClosePopUp()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#at-cv-lightbox-close"))
                    .Displayed); 
            Driver.FindElement(By.CssSelector("#at-cv-lightbox-close")).Click();
        }
        public void InsertInput1(string num1)
        {
            input1.Clear();
            input1.SendKeys(num1);
        }
        
        public void InsertInput2(string num2)
        {
            input2.Clear();
            input2.SendKeys(num2);
        }
        
        public void ClickGetTotalButton()
        {
            sumButton.Click();
        }
        public void VerifyResult(string resultTxt)
        {
            Assert.AreEqual(resultTxt, result.Text, "Result is wrong");
        }
    }
}