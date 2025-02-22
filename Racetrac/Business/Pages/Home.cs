using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V129.Network;
using OpenQA.Selenium.Interactions;
using Racetrac.Business.Locators;
using Racetrac.Business.Scripts;
using Racetrac.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Racetrac.Business.Pages
{
    public class Home
    {
        private readonly Actions actions;
        private readonly Waits waits;
        private readonly SeleniumScripts scripts;
        private readonly Navbar navbar;
        

        public IWebDriver driver {  get; set; }
     

        private static string Url { get; } = "https://rtwebappqa.azurewebsites.net/";

        public Home(IWebDriver driver)    
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            actions = new Actions(driver);
            scripts = new SeleniumScripts(driver);
            waits = new Waits(driver);
            navbar = new Navbar(driver);
        }

        public Home Open() 
        {
            driver.Url = Url;
            return this;
        }

        public void ClickHomeLogo()
        {
            var homeLogo = driver.FindElement(HomeLocators.racetracIconLocator);
            homeLogo.Click();
        }
        public void AcceptCookies()
        {
            var acceptCookiesbutton = driver.FindElement(HomeLocators.cookiesAcceptLocator);
            acceptCookiesbutton.Click();
        }

        public void ClickSocialNetworkIcon(string item)
        {
            var socialNetworkElement = driver.FindElement(HomeLocators.socialNetworkItemLocator(item));
            scripts.ScrollToElement(socialNetworkElement);
            waits.WaitUntilClickable(HomeLocators.socialNetworkItemLocator(item), 5);
            Thread.Sleep(1000);
            socialNetworkElement.Click();
        }

        public bool IsSocialNetworkUrlCorrect(string socialNetwork)
        {
            string expectedUrl;
            expectedUrl = (socialNetwork) switch
            {
                ("Facebook") => "https://www.facebook.com/RaceTrac/",
                ("Instagram") => "https://www.instagram.com/racetrac/",
                ("LinkedIn") => "https://www.linkedin.com/company/racetrac",
                ("Twitter") => "https://x.com/racetrac?mx=2",
                ("TikTok") => "https://www.tiktok.com/@racetrac",
            };

            string currentUrl = navbar.SwitchToNewlyOpenedWindow();

            Console.WriteLine("Expected URL: " + expectedUrl);
            Console.WriteLine("Current URL: " + currentUrl);

            return string.Equals(expectedUrl, currentUrl, StringComparison.OrdinalIgnoreCase);
        }

    }
}
