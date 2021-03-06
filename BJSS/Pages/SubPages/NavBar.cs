﻿using OpenQA.Selenium;

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
