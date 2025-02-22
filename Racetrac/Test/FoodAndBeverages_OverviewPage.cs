using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Test
{
    internal class FoodAndBeverages_OverviewPage : TestBase
    {
        [TestCase("Breakfast")]

        public void VerifyMenuOptions(string menu)
        {
            home.AcceptCookies();
            navbar.GoToFoodAndBeveragesOption("Overview");


            //All menu items are available:
            //find and compare Beverages
            //Click breakfast options
            //verify all three items are available
            //click on X

        
        }

    }
}
