using Racetrac.Business.Pages;
using Racetrac.Core;
using Racetrac.Core.Utilities;
using Racetrac.Business.Pages.AboutUs;
using Racetrac.Business.Pages.FoodAndBeverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Racetrac.Business.Pages.FoodAndBeverages;

namespace Racetrac.Test
{
    public class TestBase
    {
        protected BrowserFactory browserFactory;
        protected Home home;
        protected Waits waits;
        protected Navbar navbar;
        protected History history;
        protected FaBOverview faBOverview;



        [SetUp]
        public void SetUp()
        {
            browserFactory = new BrowserFactory();
            InitializePageObjects();
            PrepareTestEnvironment();
        }

        private void InitializePageObjects()
        {
            home = new Home(browserFactory.Driver);
            waits = new Waits(browserFactory.Driver);
            navbar = new Navbar(browserFactory.Driver);
            history = new History(browserFactory.Driver);
            faBOverview = new FaBOverview(browserFactory.Driver);
            

        }

        private void PrepareTestEnvironment()
        {
            home.Open();        
            
        }


        [TearDown]
        public void TearDown()
        {
        browserFactory.CloseAndQuit();
        }
    }
}
