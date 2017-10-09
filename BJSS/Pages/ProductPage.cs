using OpenQA.Selenium;

namespace BJSS.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BuyButton
        {
            get
            {
                return _driver.FindElement(By.Name("Submit"));
            }
        }
    }
}
