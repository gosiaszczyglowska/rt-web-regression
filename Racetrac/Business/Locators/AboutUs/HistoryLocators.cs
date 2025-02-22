using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Locators.AboutUs
{
    internal class HistoryLocators
    {
        public static readonly By historyYearLocator = By.XPath("//div[contains(@class, 'slick-track')]//div[@aria-hidden='false']//h2[@class='history-year']");
        public static readonly By historySliderYearLocator = By.XPath("//button[contains(@class, 'slick-active')]//span[contains(@class, 'history__text')]");
        public static readonly By historyNextArrow = By.XPath("//button[@class='next slick-arrow' and @aria-label='Next']");
    }
}
