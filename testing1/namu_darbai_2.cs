using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace testing1
{
    public class namu_darbai_2
    {
        [Test]
        public static void TestChrome()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            string browserText = chrome.FindElement(By.CssSelector("#primary-detection > div")).Text;
            Assert.IsTrue(browserText.Contains("Chrome"), "Wrong browser");
            chrome.Quit();
        }
        
        [Test]
        public static void TestFirefox()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Manage().Window.Maximize();
            firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            firefox.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            string browserText = firefox.FindElement(By.CssSelector("#primary-detection > div")).Text;
            Assert.IsTrue(browserText.Contains("Firefox"), "Wrong browser");
            firefox.Quit();
        }
        
        [Test]
        public static void TestSafari()
        {
            IWebDriver safari = new SafariDriver();
            safari.Manage().Window.Maximize();
            safari.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            safari.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            string browserText = safari.FindElement(By.CssSelector("#primary-detection > div")).Text;
            Assert.IsTrue(browserText.Contains("Safari"), "Wrong browser");
            safari.Quit();
        }
    }
}