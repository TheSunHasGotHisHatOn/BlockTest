using BJSS.Enums;
using OpenQA.Selenium;

namespace BJSS.Pages.Factories
{
    public class PageFactory
    {
        private static IWebDriver _driver;
        private static HomePage _homePage = null;
        private static LoginPage _loginPage;
        private static MyAccountPage _myAccountPage;
        private static ProductPage _productPage;

        public static Browser Browser { get; set; }

        public static IWebDriver WebDriver
        {
            get
            {
                if (_driver == null)
                    _driver = DriverFactory.Get(Browser);

                return _driver;
            }
        }

        public static HomePage HomePage
        {
            get
            {
                if (_homePage == null)
                    _homePage = new HomePage(WebDriver);

                return _homePage;
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                if (_loginPage == null)
                    _loginPage = new LoginPage(WebDriver);

                return _loginPage;
            }
        }

        public static MyAccountPage MyAccountPage
        {
            get
            {
                if (_myAccountPage == null)
                    _myAccountPage = new MyAccountPage(WebDriver);

                return _myAccountPage;
            }
        }

        public static ProductPage ProductPage
        {
            get
            {
                if (_productPage == null)
                    _productPage = new ProductPage(WebDriver);

                return _productPage;
            }
        }

        public static void CleanUp()
        {
            WebDriver.Close();
            _homePage = null;
            _loginPage = null;
            _myAccountPage = null;
            _driver = null;
        }
    }
}
