using OpenQA.Selenium;
using Racetrac.Business.Locators.AboutUs;
using Racetrac.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Pages.AboutUs
{
    public class History
    {

        public IWebDriver driver { get; set; }

        public History(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
        }
        public void clickRightButton()
        {
            var nextArrowButton = driver.FindElement(HistoryLocators.historyNextArrow);
            nextArrowButton.Click();
        }
        public string VerifyYear()
        {
        var historyYear = driver.FindElement(HistoryLocators.historyYearLocator);
            var historySliderYear = driver.FindElement(HistoryLocators.historySliderYearLocator);
            Assert.That(historyYear.Text, Is.EqualTo(historySliderYear.Text).IgnoreCase);
            return historyYear.Text;
        }

        public bool areAllImportantYearsPresentedOnPage() 
        {
            var years = new List<string> {"1934", "1959", "1967", "1970s", "1975", "1976", "1979", "1996", "1998", "2004", "2012", "2016", "2017", "2019" };

            foreach (var expectedYear in years)
            {
                clickRightButton();
                Thread.Sleep(2000);
                string actualYear = VerifyYear();
                
                if (!string.Equals(actualYear, expectedYear, StringComparison.OrdinalIgnoreCase))  // Case-insensitive comparison
                {
                    return false;  // Return false if any year doesn't match
                }
            }
            return true;
        }
    }
}
