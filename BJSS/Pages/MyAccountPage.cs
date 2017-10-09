using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class MyAccountPage : IPage
    {
        private IWebDriver _driver;

        public MyAccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsHit()
        {
            return _driver.Title.ToLower() == "my account - my store";
        }
    }
}
