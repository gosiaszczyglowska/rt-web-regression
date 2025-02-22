using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racetrac.Business.Scripts
{
    public class SeleniumScripts
    {
        private readonly IWebDriver driver;
        public SeleniumScripts(IWebDriver driver) => this.driver = driver ?? throw new ArgumentException(nameof(driver));

        public void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
