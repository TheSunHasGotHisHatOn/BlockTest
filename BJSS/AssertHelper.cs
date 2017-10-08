using System;
using System.Threading;
using BJSS.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BJSS
{
    public static class AssertHelper
    {
        public static void SpinUntilHit(IWebDriver driver, IPage page, int secondsTimeout)
        {
            Assert.IsTrue(SpinWait.SpinUntil(() => page.IsHit(), TimeSpan.FromSeconds(secondsTimeout)));
        }

        public static IWebElement SpinUntilVisible(IWebDriver driver, IWebElement element, int secondsTimeout)
        {
            Assert.IsTrue(SpinWait.SpinUntil(() => element != null, TimeSpan.FromSeconds(secondsTimeout)));
            return element;
        }
    }
}
