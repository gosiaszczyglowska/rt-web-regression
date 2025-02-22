using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Locators
{
    internal class NavbarLocators
    {
        public static readonly By navFoodAndBeveragesLocator = By.Id("Food & Beverages");
        public static readonly By navFleetServicesLocator = By.XPath("//button[@id='Fleet Services']");
        public static readonly By navRewardsLocator = By.Id("Rewards");
        public static readonly By navAboutUsLocator = By.Id("About Us");
        public static By navItemLocator(string item)
        {
            return By.XPath($"//a[@class='dropdown-item' and text()='{item}']");
        }

        public static By navFleetServicesItemLocator(string item)
        {
            if (item == "Overview")
            {
                return By.XPath("//*[@id=\"navigationRoot\"]/ul[1]/li[4]/div/ul/li[1]/a");
            }
            else
            {
                return By.XPath($"//a[@class='dropdown-item' and text()='{item}']");
            }
        }

        public static By navFleetServicesFleetCardsDropdownLocator = By.XPath("//button[@id='Fleet Cards']");

        public static By navFleetServicesFleetCardsDropdownItemLocator(string subitem)
        {
            return By.XPath($"//a[@data-parent-id='Fleet Cards' and contains(text(), '{subitem}')]");
        }

        public static By navAboutUsNewsAndMediaDropdownLocator = By.XPath("//button[@id='News & Media']");

        public static By navAboutUsGiftCardsDropdownLocator = By.XPath("//button[@id='Gift Cards']");

        public static By navAboutUsRaceTracGivesBackDropdownLocator = By.XPath("//button[@id='RaceTrac Gives Back']");

        public static By navAboutUsDropdownLocator(string option)
        {
            return By.XPath($"//button[@id='{option}']");
        }
        public static By navAboutUsDropdownItemLocator(string option, string subitem)
        {
            return By.XPath($"//a[@data-parent-id='{option}' and contains(text(), '{subitem}')]");
        }



        public static readonly By navFuelLocator = By.XPath("//a[@class='nav-link' and text()='Fuel']");
        public static readonly By navOnlineOrderingLocator = By.XPath("//a[@class='nav-link' and text()='Online Ordering']");
       


        public static readonly By navCareersLocator = By.XPath("//a[@class='nav-link' and text()='Careers']");
        public static readonly By navLocationsLocator = By.XPath("//a[@class='nav-link' and text()='Locations']");

    }
}
