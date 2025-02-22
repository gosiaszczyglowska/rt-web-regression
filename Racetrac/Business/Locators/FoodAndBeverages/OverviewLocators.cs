using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Locators.FoodAndBeverages
{
    internal class OverviewLocators
    {
        public static By menuLocator(string menu)
        {
            return By.XPath($"//h2[@class='h2likeh3 pl-0' and contains(text(), '{menu}')]");
        }

        public static readonly By showBreakfastMenuItemsLocator = By.XPath("//button[@data-target='#Breakfast-Options'");

    }
}
