using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Scripts
{
    public class ComplexActions
    {

        private readonly IWebDriver driver;

        public ComplexActions(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public void ClickHere(IWebElement element)
        {
            new OpenQA.Selenium.Interactions.Actions(driver)
                    .Click(element);
        }

        public void HoverOver(IWebElement element)
        {
        
        }
    }
}
