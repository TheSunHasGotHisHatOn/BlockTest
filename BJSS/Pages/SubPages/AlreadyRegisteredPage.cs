using OpenQA.Selenium;

namespace BJSS.Pages.SubPages
{
    public class AlreadyRegisteredPage
    {
        private IWebDriver _driver;

        public AlreadyRegisteredPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement EmailTextBox
        {
            get { return _driver.FindElement(By.Id("email")); }
        }

        public IWebElement PasswordTextBox
        {
            get { return _driver.FindElement(By.Id("passwd")); }
        }

        public IWebElement SubmitButton
        {
            get { return _driver.FindElement(By.Id("SubmitLogin")); }
        }
    }
}
