using System.Threading;
using NUnit.Framework;

namespace Airbnb_baigiamasis_projektas.Test
{
    public class AirbnbTest: BaseTest
    {
        [Test]
        public static void TestFlexibleBeachfront()
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ChooseBeachfrontOption();
            flexiblePage.VerifyBeachfrontResults();
        }

        [Test]
        public static void TestWeekendFilter()
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ClickButtonAnytime();
            flexiblePage.ClickButtonWeekend();
            flexiblePage.ClickButtonSave();
            flexiblePage.VerifyWeekendResults();
        }
        
        [Test]
        public static void TestPriceFilter()
        {
            homePage.NavigateToPage();
            homePage.ClickFlexibleButton();
            flexiblePage.ClickOnFilters();
            flexiblePage.InsertPriceRange();
        }

        
        [Test]
        public static void TestSignupInsertWrongPhoneNumber()
        {
            homePage.NavigateToPage();
            homePage.ClickProfileButton();
            homePage.ClickSignupButton();
            homePage.SelectCountry();
            homePage.InsertPhoneNumber("456");
            homePage.ClickContinueButton();
            homePage.VerifyWrongPhoneNumberMessage(); //todo: stiliu patikrinti
        }
        
        [Test]
        public static void TestSignupInsertTooLongPhoneNumber()
        {
            homePage.NavigateToPage();
            homePage.ClickProfileButton(); //reiktu thread sleepu bandyt
            homePage.ClickSignupButton();
            homePage.InsertPhoneNumber("45699999999997");
            homePage.ClickContinueButton();
            homePage.VerifyTooLongPhoneNumberMessage(); //todo: stiliu patikrinti
        }
        
        [Test]
        public static void TestAveragePriceFor2AdultsOctober()
        {
            homePage.NavigateToPage();
            Thread.Sleep(4000);
            homePage.InsertLocationInput();
            homePage.AddDate();
            homePage.AddGuests();
            Thread.Sleep(2000);
            homePage.ClickSearchButton();
            searchResultsPage.ClickPriceButton();
            searchResultsPage.VerifyAveragePriceResults();
        }
        
        [Test]
        public static void TestOnlineExperiencesLanguageFilter()
        {
            homePage.NavigateToPage();
            homePage.ChooseExperiences();
            onlineExperiencesPage.ChooseFilters();
            Thread.Sleep(3000);
            onlineExperiencesPage.ChooseLanguage();
            onlineExperiencesPage.ShowFilteredResults();
            Thread.Sleep(3000);
            onlineExperiencesPage.ChooseDance();
            onlineExperiencesPage.VerifyFilteredResults();
        }
    }
}