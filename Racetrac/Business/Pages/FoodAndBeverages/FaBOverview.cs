using OpenQA.Selenium;
using FluentAssertions;
using Racetrac.Business.Locators;
using Racetrac.Business.Locators.FoodAndBeverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Pages.FoodAndBeverages
{
    public class FaBOverview
    {
        public IWebDriver driver { get; set; }

        public FaBOverview(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
        }

        public void MenuIsOnThePage(string menuname)
        {

                var menu = driver.FindElement(OverviewLocators.menuLocator(menuname));
                

        }




    }
}
