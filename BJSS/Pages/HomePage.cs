using System;
using System.Collections.ObjectModel;
using BJSS.Pages.SubPages;
using BJSS.TestObjects;
using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class HomePage : IPage
    {
        private readonly IWebDriver _driver;

        public NavBar NavBar { get; private set; }

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            NavBar = new NavBar(driver);
        }

        public bool IsHit()
        {
            return _driver.Title.ToLower() == AppSettings.HomepageTitle;
        }

        public bool NavigateTo()
        {
             _driver.Url = AppSettings.AutomationPracticeBaseUri;
            
            return IsHit();
        }

        public ReadOnlyCollection<IWebElement> FeaturedItems
        {
            get
            {
                try
                {
                    return _driver.FindElements(By.XPath(".//*[@class='product-container']"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
