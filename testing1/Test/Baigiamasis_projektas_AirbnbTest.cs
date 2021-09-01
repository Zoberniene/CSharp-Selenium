using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testing1.Page;

namespace testing1.Test
{
    public class Baigiamasis_projektas_AirbnbTest: BaseTest
    {

        [Test]
        public static void TestFlexibleBeachfront()
        {
            baigiamasisProjektasAirbnbPage.NavigateToPage();
            baigiamasisProjektasAirbnbPage.ClickFlexibleButton();
            baigiamasisProjektasAirbnbPage.ChooseBeachfrontOption();
            baigiamasisProjektasAirbnbPage.ClickButtonAnytime();
            baigiamasisProjektasAirbnbPage.ClickButtonWeekend();
            baigiamasisProjektasAirbnbPage.ClickButtonSave();
            baigiamasisProjektasAirbnbPage.VerifyBeachfrontResults();
        }
    }
}