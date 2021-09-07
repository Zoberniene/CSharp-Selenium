using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Page;

namespace testing1.Test
{
    public class Papildomi_ND_SebTest
    {
        private static Papildomi_ND_SebPage page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new Papildomi_ND_SebPage(chrome);

            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //page.CloseBrowser();
        }
        
        [Test]
        public static void TestCredit()
        {
            page.AcceptCookies();
            page.InsertIncome();
            page.SelectCity();
            page.Calculate();
            page.VerifyCreditSum();
        }
    }
}