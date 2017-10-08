using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJSS.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BJSS
{
    // todo: check that nuget can be used by bjss peeps
    // todo: find better place (than bin) to stick geckodriver.exe
    [TestFixture]
    public class TestClass1
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private MyAccountPage _myAccountPage;

        private const string EMAIL = "katiecookson@hotmail.com";
        private const string PASSWORD = "BJSSTest";

        [SetUp]
        public void Initialise()
        {
            _driver = new FirefoxDriver();
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _myAccountPage = new MyAccountPage(_driver);
        }

        //[TestCase(Firefox)]
        //[TestCase(IE)]
        [Test]
        public void Test1(string browser)
        {
           /* _driver.Url = "http://automationpractice.com/index.php";
            var loginButton = _driver.FindElement(By.ClassName("login"));
            loginButton.Click();*/

            // maybe navigate should be a class?
            _homePage.NavigateTo();
            _homePage.NavBar.LoginButton.Click();

            Assert.That(_loginPage.IsHit(), Is.True,"Login page was not loaded.");

            _loginPage.AlreadyRegisteredPage.EmailTextBox.Clear();
            _loginPage.AlreadyRegisteredPage.EmailTextBox.SendKeys(EMAIL);

            _loginPage.AlreadyRegisteredPage.PasswordTextBox.Clear();
            _loginPage.AlreadyRegisteredPage.PasswordTextBox.SendKeys(PASSWORD);

            _loginPage.AlreadyRegisteredPage.SubmitButton.Click();

           // System.Threading.Thread.Sleep(5000);

            //Assert.That(_myAccountPage.IsHit(), Is.True, "My Account Page was not hit");
            AssertHelper.SpinUntilHit(_driver, _myAccountPage, secondsTimeout:5);
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Close();
        }
    }
}
