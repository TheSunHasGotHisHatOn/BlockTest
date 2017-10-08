using System;
using BJSS.Pages.SubPages;
using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class HomePage : IPage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException();

            _driver = driver;
            NavBar = new NavBar(driver);
        }

        public bool IsHit()
        {
            return _driver.Title.ToLower() == "my store";
        }

        public bool NavigateTo()
        {
            _driver.Url = "http://automationpractice.com/index.php";
            return IsHit();
        }

       /* public IWebElement LoginButton
        {
            get
            {
                return _driver.FindElement(By.ClassName("login"));
            }
        }*/

        public NavBar NavBar { get; private set; }
    }
}
