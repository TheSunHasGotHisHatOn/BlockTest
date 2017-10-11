using System;
using System.Collections.ObjectModel;
using BJSS.Pages.SubPages;
using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class HomePage : IPage
    {
        private IWebDriver _driver;

        public NavBar NavBar { get; private set; }

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
            try
            {
                _driver.Url = "http://automationpractice.com/index.php";
            }
            catch (Exception ex)
            { 
                throw;
            }
            
            return IsHit();
        }

        public ReadOnlyCollection<IWebElement> FeaturedItems
        {
            get
            {
                //return _driver.FindElement(By.Id("homefeatured"));
                //return _driver.FindElements(By.XPath(".//*[@class='button ajax_add_to_cart_button btn btn-default']"));
                //return _driver.FindElements(By.XPath(".//*[@class='quick-view']"));
                return _driver.FindElements(By.XPath(".//*[@class='product-container']"));
               // return _driver.FindElements(By.XPath(".//*[@class='ajax_block_product']"));
            }
        }
    }
}
