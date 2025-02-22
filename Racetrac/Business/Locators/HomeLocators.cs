using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Locators
{
    public static class HomeLocators
    {
        public static readonly By racetracIconLocator = By.XPath("//img[@alt='RaceTrac Logo']");
        public static readonly By cookiesAcceptLocator = By.Id("onetrust-accept-btn-handler");
        public static readonly By cookiesRejectLocator = By.Id("onetrust-reject-btn-handler");
        public static readonly By stayConnectedLocator = By.ClassName("social");

        public static By socialNetworkItemLocator(string item)
        {
            return By.XPath($"//a[@class='socialIcon' and @aria-label='{item}']");
        }
    }
}
