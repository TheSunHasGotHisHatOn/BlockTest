using System;
using OpenQA.Selenium;

namespace BJSS.Pages.SubPages
{
    public class AlreadyRegisteredPage
    {
        private readonly IWebDriver _driver;

        public AlreadyRegisteredPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement EmailTextBox
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.Id("email"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.Id("passwd"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                try
                {
                    return _driver.FindElement(By.Id("SubmitLogin"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
