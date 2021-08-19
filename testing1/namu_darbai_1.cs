using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testing1
{
    public class namu_darbai_1 {
    [Test]
        public static void TestTwoInputFields1()
        {
            IWebDriver chrome = new ChromeDriver(); //sukuriamas objektas, jo pavadinimas chrome
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            //uzdaryti pop-up
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#at-cv-lightbox-close"))
                    .Displayed); //d kaip atitikmuo driver, galima irasyti ka nori
            chrome.FindElement(By.CssSelector("#at-cv-lightbox-close")).Click();

            IWebElement input1 = chrome.FindElement(By.Id("sum1"));
            IWebElement input2 = chrome.FindElement(By.Id("sum2"));
            IWebElement sumButton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            
            input1.SendKeys("2");
            input2.SendKeys("2");
            sumButton.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            //result = result.GetAttribute("value");
            Assert.AreEqual("4", result.Text, "Result is wrong");
        }
        
        [Test]
        public static void TestTwoInputFields2()
        {
            IWebDriver chrome = new ChromeDriver(); //sukuriamas objektas, jo pavadinimas chrome
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            //uzdaryti pop-up
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#at-cv-lightbox-close"))
                    .Displayed); //d kaip atitikmuo driver, galima irasyti ka nori
            chrome.FindElement(By.CssSelector("#at-cv-lightbox-close")).Click();

            IWebElement input1 = chrome.FindElement(By.Id("sum1"));
            IWebElement input2 = chrome.FindElement(By.Id("sum2"));
            IWebElement sumButton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            
            input1.SendKeys("-5");
            input2.SendKeys("3");
            sumButton.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            //result = result.GetAttribute("value");
            Assert.AreEqual("-2", result.Text, "Result is wrong");
        }
        
        [Test]
        public static void TestTwoInputFields3()
        {
            IWebDriver chrome = new ChromeDriver(); //sukuriamas objektas, jo pavadinimas chrome
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            //uzdaryti pop-up
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(d =>
                d.FindElement(By.CssSelector("#at-cv-lightbox-close"))
                    .Displayed); //d kaip atitikmuo driver, galima irasyti ka nori
            chrome.FindElement(By.CssSelector("#at-cv-lightbox-close")).Click();

            IWebElement input1 = chrome.FindElement(By.Id("sum1"));
            IWebElement input2 = chrome.FindElement(By.Id("sum2"));
            IWebElement sumButton = chrome.FindElement(By.CssSelector("#gettotal > button"));
            
            input1.SendKeys("a");
            input2.SendKeys("b");
            sumButton.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            //result = result.GetAttribute("value");
            Assert.AreEqual("NaN", result.Text, "Result is wrong");
            
        }
    }
}