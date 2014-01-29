using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests.Basic.Shared
{
    /// <summary>
    /// Manages shared WebDriver instance used by tests
    /// </summary>
    public class WebDriverStore
    {
        private static Lazy<IWebDriver> driverInitializer = null;

        static WebDriverStore()
        {
            ResetDriver();
        }

        public static IWebDriver WebDriver
        {
            get
            {
                return driverInitializer.Value;
            }
        }

        public static void ResetDriver()
        {
            if (driverInitializer != null && driverInitializer.IsValueCreated)
            {
                driverInitializer.Value.Quit();
            }
            driverInitializer = new Lazy<IWebDriver>(() => new ChromeDriver(".")); 
        }
    }
}