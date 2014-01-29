using OpenQA.Selenium;

namespace SeleniumDemo.Tests.UI.Infrastructure
{
    public abstract class Element : IElement
    {
        public void Init(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; private set; }

        protected void ClickAndWaitForPageToLoad(string description, string locator)
        {
//            if (!Driver.IsElementPresent(locator))
//            {
//                string message = string.Format(@"The page element ""{0}"" could not be found using pattern {1} on the page at url {2}. The tests may need to be updated in line with layout changes. ", description, locator, Driver.Url);
//                throw new UnexpectedPageContentException(message);
//            }
//            Browser.Click(locator);
//            Browser.WaitForPageToLoad(BrowseSettings.LoadTimeout.ToString());
        }

        protected void TypeById(string elementId, string text)
        {
            string locator = string.Format("//input[@id='{0}']", elementId);
            TypeByLocator(locator, text);
        }

        protected void TypeByLocator(string locator, string text)
        {
//            Browser.Type(locator, text);
        }
    }
}