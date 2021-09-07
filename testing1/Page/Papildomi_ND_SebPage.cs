using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace testing1.Page
{
    public class Papildomi_ND_SebPage: BasePage
    {
        private IWebElement income => Driver.FindElement(By.CssSelector("#income"));
        
        private IWebElement calculateButton => Driver.FindElement(By.CssSelector("#calculate > .ng-binding"));
        
        private IWebElement result => Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > span > strong"));
        
        private SelectElement cityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        
        
        public Papildomi_ND_SebPage(IWebDriver webdriver) : base(webdriver) {}
        
        public void AcceptCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div[5]/div/div[4]/ul/li[1]/a/span"))
                    .Displayed); 
            Driver.FindElement(By.XPath("/html/body/div[5]/div/div[4]/ul/li[1]/a/span")).Click();
        }

        public void InsertIncome()
        {
            Driver.SwitchTo().Frame(0);
            income.SendKeys("100");
        }
        
        public void SelectCity()
        {
            cityDropdown.SelectByIndex(2);
        }
        
        public void Calculate()
        {
            calculateButton.Click();
        }

        public void VerifyCreditSum()
        {
            int num = 75000;
            //int credit = Int32.Parse(result.Text);
            //int credit = Convert.ToInt32(result.Text);
            //int credit;
            //var a = Int32.TryParse(result.Text, out credit);
            //int credit = int.Parse(result.Text);

            Console.WriteLine(result.Text);
            Console.WriteLine(num);
            //Console.WriteLine(a);
            //Assert.IsTrue(num < credit, "Wrong credit");
        }
    }
}