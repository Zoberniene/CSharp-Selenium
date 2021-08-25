using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using testing1.Page;

namespace testing1.Test
{
    public class Namu_darbai_3Test
    {
        private static Namu_darbai_3Page page;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            IWebDriver chrome = new ChromeDriver();
            page = new Namu_darbai_3Page(chrome);

            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            page.ClosePopUp();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("2", "2", "4", TestName = "2plus2")]
        [TestCase("-5", "3", "-2", TestName = "-5plus3")]
        [TestCase("a", "b", "NaN", TestName = "aplusb")]
        public static void TestCases(string num1, string num2, string resultTxt)
        {
            page.InsertInput1(num1);
            page.InsertInput2(num2);
            page.ClickGetTotalButton();
            page.VerifyResult(resultTxt);
        }
    }
}