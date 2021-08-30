using System;
using System.Collections.Generic;
using System.Linq;
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
            page.AcceptCookies();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            page.CloseBrowser();
        }

        [TestCase("Volvo", "Opel", TestName ="Selected Volvo, Opel")]
        [TestCase("Volvo", "Saab", "Audi", TestName = "Selected Volvo, Saab, Audi")]
        [TestCase("Audi", "Saab", TestName = "Selected Audi, Saab")]
        public static void TestSelectingMultipleCars(params string[] cars)
        {
            List<string> carsList = cars.ToList();
            page.SelectCars(carsList);
            page.ClickSubmitButton();
            page.VerifySelectedCarsResult(carsList);
            page.RerunPage();
        }
    }
}