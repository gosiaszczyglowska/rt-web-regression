using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Racetrac.Test
{
    public class NavTests : TestBase
    {


        [TestCase("Overview")]
        [TestCase("Coffee")]
        [TestCase("Pizza")]
        [TestCase("Fountain Drinks")]
        [TestCase("Frozen Drinks")]
        public void FoodAndBeveragesNavCheck(string item)
        {
            home.AcceptCookies();
            navbar.GoToFoodAndBeveragesOption(item);
        }
        public void FuelNavCheck()
        {
            home.AcceptCookies();
            navbar.GoToFuel();
        }

        [TestCase("Food & Beverages", "Overview")]
        [TestCase("Food & Beverages", "Coffee")]
        [TestCase("Food & Beverages", "Pizza")]
        [TestCase("Food & Beverages", "Fountain Drinks")]
        [TestCase("Food & Beverages", "Frozen Drinks")]
        [TestCase("Fuel")]
        [TestCase("Online Ordering")]
        [TestCase("Fleet Services", "Overview")]
        [TestCase("Fleet Services", "Small Business & Fleet Services")]
        [TestCase("Fleet Services", "Travel Center & High-Flow Diesel Network")]
        [TestCase("Fleet Services", "Fleet Cards", "Access Fleet Cards")]
        [TestCase("Fleet Services", "Fleet Cards", "Learn More")]
        [TestCase("Rewards", "RaceTrac Rewards")]
        [TestCase("Rewards", "RaceTrac Rewards VIP")]
        [TestCase("Rewards", "Rewards + Debit")]
        [TestCase("Rewards", "Community Offers")]
        [TestCase("About Us", "History")]
        [TestCase("About Us", "News & Media", "Press Resources")]
        [TestCase("About Us", "News & Media", "Stories")]
        [TestCase("About Us", "Gift Cards", "Buy A Card")]
        [TestCase("About Us", "Gift Cards", "Check Your Balance")]
        [TestCase("About Us", "Gift Cards", "Reload Your Card")]
        [TestCase("About Us", "RaceTrac Gives Back", "About")]
        [TestCase("About Us", "RaceTrac Gives Back", "Run for Research")]
        [TestCase("About Us", "Real Estate")]
        [TestCase("About Us", "FAQs")]
        [TestCase("About Us", "Contact Us")]
        [TestCase ("Careers")]
        [TestCase ("Locations")]
        public void VerifyUrlsCorrectness(string category, string item = null, string suboption = null)
        {
            home.AcceptCookies();
            navbar.GoToPage(category, item, suboption);
            bool isUrlCorrect = navbar.IsTheUrlCorrect(category, item, suboption);

            Assert.IsTrue(isUrlCorrect, $"Expected URL for {category}/{item} is not correct");
        }


    }
}
