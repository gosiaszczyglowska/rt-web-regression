using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Test
{
    public class HistoryPage : TestBase
    {
        [Test]
        public void CheckIfAllImportantDatesArePresent()
        {
            home.AcceptCookies();
            navbar.GoToAboutUsOption("History");
            Assert.IsTrue(history.areAllImportantYearsPresentedOnPage());         
        }
    }
}
