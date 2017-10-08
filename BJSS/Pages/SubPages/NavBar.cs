using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BJSS.Pages.SubPages
{
    public class NavBar
    {
        private IWebDriver _driver;

        public NavBar(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.ClassName("login"));
            }
        }
    }
}
