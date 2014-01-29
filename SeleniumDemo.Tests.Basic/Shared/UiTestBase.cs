using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumDemo.Tests.Basic.Shared
{
    public abstract class UiTestBase
    {
        protected readonly string Root = ConfigurationManager.AppSettings["UiTesting.WebSiteRoot"];

        public IWebDriver Driver
        {
            get { return WebDriverStore.WebDriver; }
        }

        [SetUp]
        public void CommonTestSetup()
        {
            ResetSession();
        }
        
        private void ResetSession()
        {
            Driver.Navigate().GoToUrl(Root + "testsupport/reset");
            TestDbHelper.ResetData();
        }


        protected void InputText(string value, string inputId)
        {
            var inputElement = Driver.FindElement(By.Id(inputId));
            inputElement.SendKeys(value);
        }

        protected void SubmitForm(string inputId)
        {
            var inputElement = Driver.FindElement(By.Id(inputId));
            inputElement.Submit();
        }

        protected void GoToUrl(string path)
        {
            Driver.Navigate().GoToUrl(Root + path);
        }
    }
}