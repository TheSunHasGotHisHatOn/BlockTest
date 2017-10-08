using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class LoginPage : IPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            AlreadyRegisteredPage = new AlreadyRegisteredPage(driver);
        }

        public bool IsHit()
        { 
            return _driver.Title.ToLower() == "login - my store";
        }

        public AlreadyRegisteredPage AlreadyRegisteredPage { get; private set; }
    }
}
