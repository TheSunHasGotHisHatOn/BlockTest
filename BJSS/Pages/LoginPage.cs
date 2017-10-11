using BJSS.Pages.SubPages;
using BJSS.TestObjects;
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
            return _driver.Title.ToLower() == AppSettings.LoginpageTitle;
        }

        public AlreadyRegisteredPage AlreadyRegisteredPage { get; private set; }
    }
}
