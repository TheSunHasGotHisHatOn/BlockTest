using System;
using OpenQA.Selenium;

namespace BJSS.Pages.SubPages
{
    public class NavBar
    {
        private readonly IWebDriver _driver;

        public NavBar(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginButton
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.ClassName("login"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
