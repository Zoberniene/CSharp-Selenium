using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testing1
{
    public class namu_darbai_1 {
        
        private static IWebDriver chrome;
        
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            chrome = new ChromeDriver(); 
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(10); 
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#at-cv-lightbox-close"))
                    .Displayed); //d kaip atitikmuo driver, galima irasyti ka nori
            chrome.FindElement(By.CssSelector("#at-cv-lightbox-close")).Click();
            
        }

        [OneTimeTearDown] 
        public static void OneTimeTearDown()
        {
            chrome.Quit();
        }
        
        [TestCase("2", "2", "4", TestName = "2plus2")]
        [TestCase("-5", "3", "-2", TestName = "-5plus3")]
        [TestCase("a", "b", "NaN", TestName = "aplusb")]
        public static void TestCases(string num1, string num2, string resultTxt)
        {
            IWebElement input1 = chrome.FindElement(By.Id("sum1"));
            IWebElement input2 = chrome.FindElement(By.Id("sum2"));
            IWebElement sumButton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            
            input1.Clear();
            input1.SendKeys(num1);
            input2.Clear();
            input2.SendKeys(num2);
            sumButton.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(resultTxt, result.Text, "Result is wrong");
        }
    }
}