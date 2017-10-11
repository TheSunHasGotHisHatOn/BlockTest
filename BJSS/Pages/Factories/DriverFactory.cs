using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJSS.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BJSS.Pages.Factories
{
    public class DriverFactory
    {
        public static IWebDriver Get(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    return new ChromeDriver();
                case Browser.Firefox:
                    return new FirefoxDriver();
                case Browser.InternetExplorer:
                {
                    // for some reason this isn't working properly - not finding login
                    // may need to have different page objects for different browsers
                    return new InternetExplorerDriver();
                }
                default:
                    return new FirefoxDriver();
            }
        }
    }
}
