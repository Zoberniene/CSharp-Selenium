using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Page;

namespace testing1.Test
{
    public class Namu_darbai_4Test
    {
        private static Namu_darbai_4Page page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new Namu_darbai_4Page(chrome);

            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_select_multiple";
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //page.CloseBrowser();
        }


        [Test]
        public static void TestButton()
        {
            page.AcceptCookies();
            //Thread.Sleep(5000);
            page.ClickSubmitButton();



        }
    }
}