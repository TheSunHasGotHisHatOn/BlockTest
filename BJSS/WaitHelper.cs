﻿using System;
using System.Threading;
using BJSS.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BJSS
{
    public static class WaitHelper
    {
        public static void SpinUntilHit(IWebDriver driver, IPage page, int secondsTimeout, string message = "")
        {
            Assert.IsTrue(SpinWait.SpinUntil(() => page.IsHit(), TimeSpan.FromSeconds(secondsTimeout)), message);
        }

        public static IWebElement SpinUntilVisible(IWebDriver driver, IWebElement element, string elementName, int secondsTimeout, string message = "")
        {
            Assert.That(element, Is.Not.Null, "Element '{0}' was null", elementName);
            Assert.IsTrue(SpinWait.SpinUntil(() => element != null, TimeSpan.FromSeconds(secondsTimeout)), message);
            return element;
        }
    }
}
