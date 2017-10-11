using System;
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
                try
                {
                    return _driver.FindElement(By.Name("Submit"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
