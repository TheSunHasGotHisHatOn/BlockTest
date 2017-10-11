using BJSS.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

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
                default:
                    return new FirefoxDriver();
            }
        }
    }
}
