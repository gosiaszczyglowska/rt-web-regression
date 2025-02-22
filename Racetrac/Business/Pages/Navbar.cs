using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.BiDi.Modules.Session;
using OpenQA.Selenium.Interactions;
using Racetrac.Business.Locators;
using Racetrac.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Racetrac.Business.Pages
{
    public class Navbar
    {
        private readonly Waits waits;
        public IWebDriver driver { get; set; }

        public Navbar(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            waits = new Waits(driver);
        }

        public void GoToFoodAndBeverages()
        {
            var navFoodAndBeverages = driver.FindElement(NavbarLocators.navFoodAndBeveragesLocator);
            navFoodAndBeverages.Click();
            waits.Wait(5);
            Console.WriteLine("REached food and ebverages nav");
        }
        public void GoToFuel()
        {
             var navFuel = driver.FindElement(NavbarLocators.navFuelLocator);
            navFuel.Click();
            waits.Wait(5);
        }
        public void GoToOnlineOrdering()
        {
            var navOnlineOrdering = driver.FindElement(NavbarLocators.navOnlineOrderingLocator);
            navOnlineOrdering.Click();
            waits.Wait(5);
         
        }
        public void GoToFleetServices()
        {
            var navFleetServices = driver.FindElement(NavbarLocators.navFleetServicesLocator);
            navFleetServices.Click();
            waits.Wait(5);
        }

        public void GoToFleetServicesOption(string option, string suboption = null)
        {
            GoToFleetServices();
            if (string.IsNullOrEmpty(suboption))
            {
                var item = driver.FindElement(NavbarLocators.navFleetServicesItemLocator(option));           
                item.Click();
            }

           else if (!string.IsNullOrEmpty(suboption))
            {
                var navFleetCardsDropdown = driver.FindElement(NavbarLocators.navFleetServicesFleetCardsDropdownLocator);
                navFleetCardsDropdown.Click();

                var navFleetCardsDropdownOption = driver.FindElement(NavbarLocators.navFleetServicesFleetCardsDropdownItemLocator(suboption));
                navFleetCardsDropdownOption.Click();
            }

            waits.Wait(5);
        }

        public void GoToRewards()
        {
            var navRewards = driver.FindElement(NavbarLocators.navRewardsLocator);
            navRewards.Click();
            waits.Wait(5);
        }

        public void GoToRewardsOption(string option)
        {
            GoToRewards();
            var item = driver.FindElement(NavbarLocators.navItemLocator(option));
            item.Click();
            waits.Wait(5);
        }
        public void GoToAboutUs() 
        {
            var navAboutUs = driver.FindElement(NavbarLocators.navAboutUsLocator);
            navAboutUs.Click();
            waits.Wait(5);
        }

        public void GoToAboutUsOption(string option, string suboption = null)
        {
        GoToAboutUs();
            if (string.IsNullOrEmpty(suboption))
            {
                var item = driver.FindElement(NavbarLocators.navItemLocator(option));
                item.Click();
            }

            else if (!string.IsNullOrEmpty(suboption))
            {
                var navAboutUsDropdown = driver.FindElement(NavbarLocators.navAboutUsDropdownLocator(option));
                navAboutUsDropdown.Click();
                var navAboutUsDropdownItem = driver.FindElement(NavbarLocators.navAboutUsDropdownItemLocator(option, suboption));
                navAboutUsDropdownItem.Click();
             }
        }
        public void GoToCareers() 
        {
            var navCareers = driver.FindElement(NavbarLocators.navCareersLocator);
            navCareers.Click();
            waits.Wait(5);
        }
        public void GoToLocations() 
        {
            var navLocations = driver.FindElement(NavbarLocators.navLocationsLocator);
            navLocations.Click();
            waits.Wait(5);
        }

              
        public void GoToFoodAndBeveragesOption(string option)
        {
            GoToFoodAndBeverages();
            var item = driver.FindElement(NavbarLocators.navItemLocator(option));
            item.Click();
            waits.Wait(5);
        }

        public bool IsTheUrlCorrect(string category, string option = null, string suboption = null)
        {
            string expectedUrl;
            string sanitizedCategory = category.Replace(" ", "-").Replace("&", "");
            sanitizedCategory = Regex.Replace(sanitizedCategory, "-+", "-");
            string sanitizedOption = (option ?? string.Empty).Replace(" ", "-").Replace("&", "");
            sanitizedOption = Regex.Replace(sanitizedOption, "-+", "-");

            expectedUrl = (category, option, suboption) switch
            {
                ("Food & Beverages", "Overview", _) => "https://rtwebappqa.azurewebsites.net/Food-Beverages",
                ("Online Ordering", _, _) => "https://rtwebappqa.azurewebsites.net/Order-Online",
                ("Locations", _, _) => "https://rtwebappqa.azurewebsites.net/Locations",
                ("Careers", _, _) => "https://careers.racetrac.com/us/en",
                ("Fuel", _, _) => "https://rtwebappqa.azurewebsites.net/Fuel/Traditional-Fuel",
                (_, "Rewards + Debit", _) => "https://rtwebappqa.azurewebsites.net/Rewards/Rewardscard",
                (_, "Community Offers", _) => "https://rtwebappqa.azurewebsites.net/Rewards/CommunityOffers",
                (_, _, "Access Fleet Cards") => "https://racetrac.wexonline.com/login",
                (_, _, "Learn More") => "https://www.racetracfleetcard.com/",
                (_, _, "Run for Research") => "https://rtwebappqa.azurewebsites.net/About-Us/Run-For-Research",
                (_, _, "Press Resources") => "https://rtwebappqa.azurewebsites.net/About-Us/News-Media/Press-Resources",
                (_, _, "Check Your Balance") => "https://racetrac.cashstar.com/recipient-experience/balance/",
                (_, _, "Buy A Card") => "https://racetrac.cashstar.com/store/recipient",
                (_, _, "Reload Your Card") => "https://racetrac.cashstar.com/reload/",
                (_, _, "Stories") => "https://rtwebappqa.azurewebsites.net/About-Us/News-Media/Articles",
                _ => $"https://rtwebappqa.azurewebsites.net/{sanitizedCategory}/{sanitizedOption}"
            };

            string currentUrl = driver.Url;

            if (expectedUrl == "https://racetrac.wexonline.com/login" 
                || expectedUrl == "https://www.racetracfleetcard.com/" 
                || expectedUrl == "https://racetrac.cashstar.com/recipient-experience/balance/" 
                || expectedUrl == "https://racetrac.cashstar.com/store/recipient" 
                || expectedUrl == "https://racetrac.cashstar.com/reload/")

            {
            currentUrl = SwitchToNewlyOpenedWindow();
            }

            Console.WriteLine("Expected URL: " + expectedUrl);
            Console.WriteLine("Current URL: " + currentUrl);

            return string.Equals(expectedUrl, currentUrl, StringComparison.OrdinalIgnoreCase);
        }

        public void GoToPage(string category, string item = null, string suboption = null)
        {

            if (string.IsNullOrEmpty(category))
            {
            throw new ArgumentException(nameof(category));
            }

            switch (category) 
            {
                case "Food & Beverages":

                    GoToFoodAndBeveragesOption(item);
                    break;

                case "Fuel":

                    GoToFuel();
                    break;

                case "Online Ordering":

                    GoToOnlineOrdering();
                    break;

                case "Fleet Services":

                    GoToFleetServicesOption(item, suboption);
                    break;

                case "Rewards":
                    GoToRewardsOption(item);
                    break;

                case "About Us":
                    GoToAboutUsOption(item, suboption);
                    break;

                case "Careers":
                    GoToCareers();
                    break;

                case "Locations":
                    GoToLocations();
                    break;

                default:
                    throw new ArgumentException($"Invalid category {category}", nameof(category));


            }     
        }
/*
        public bool IsSocialNetworkUrlCorrect(string socialNetwork)
        {
            string expectedUrl;
            expectedUrl = (socialNetwork) switch
            {
                ("Facebook") => "https://www.facebook.com/RaceTrac/",
                ("Instagram") => "https://www.instagram.com/racetrac/",
                ("LinkedIn") => "https://www.linkedin.com/company/racetrac",
                ("Twitter") => "https://x.com/racetrac",
                ("TikTok") => "https://www.tiktok.com/@racetrac",
            };

            string currentUrl = SwitchToNewlyOpenedWindow();

            Console.WriteLine("Expected URL: " + expectedUrl);
            Console.WriteLine("Current URL: " + currentUrl);

            return string.Equals(expectedUrl, currentUrl, StringComparison.OrdinalIgnoreCase);
        }*/

        public string SwitchToNewlyOpenedWindow()
        {
            var currentWindowHandle = driver.CurrentWindowHandle;
            var allWindowHandles = driver.WindowHandles;

            foreach (var handle in allWindowHandles)
            {
                if (handle != currentWindowHandle)
                {
                    driver.SwitchTo().Window(handle); 
                    break;
                }
            }
            return driver.Url;
        }

    }
}

