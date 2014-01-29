using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumDemo.Tests.UI.Basic.Accounts
{
    /// <summary>
    /// Demonstrates how to write tests in simple unit test style with raw Selenium API 
    /// This wouldn't scale well to large number of tests, but it gives a good introduction to 
    /// various aspects of working with Selenium
    /// </summary>
	[TestFixture]
	public class AccountTests
	{
		private string root = ConfigurationManager.AppSettings["UiTesting.WebSiteRoot"];
		private IWebDriver driver;

		[TestFixtureSetUp]
		public void FixtureSetup()
		{
			driver = new ChromeDriver("..\\..\\..\\Tools\\chromedriver_win_23.0.1240.0\\");
		}

		[TestFixtureTearDown]
		public void FixtureTeardown()
		{
			driver.Quit();
		}

		[SetUp]
		public void Setup()
		{
            driver.Navigate().GoToUrl(root + "testsupport/reset");
		}

		[TearDown]
		public void Teardown()
		{
			
		}


		[Test]
		public void when_not_logged_in_should_be_redirected_to_login_screen()
		{
			driver.Navigate().GoToUrl(root);

			var uri = new Uri(driver.Url);
			Assert.AreEqual("/Account/Login", uri.LocalPath);
		}

        [Test]
        public void after_registering_should_be_logged_in()
        {
            CompleteRegistrationForm("mike", "fluffybunnykins");

            var uri = new Uri(driver.Url);
            Assert.AreEqual("/", uri.LocalPath, "Should redirect to home page");

            var info = driver.FindElement(By.Id("login"));
            StringAssert.StartsWith("Hello, mike", info.Text, "Should display logged in status");
        }

        [Test]
        public void after_logging_in_should_be_logged_in()
        {
            CompleteRegistrationForm("mike", "fluffybunnykins");
            LogOut();
            CompleteLogInForm("mike", "fluffybunnykins");

            var uri = new Uri(driver.Url);
            Assert.AreEqual("/", uri.LocalPath, "Should redirect to home page");

            var info = driver.FindElement(By.Id("login"));
            StringAssert.StartsWith("Hello, mike", info.Text, "Should display logged in status");
        }

        private void LogOut()
        {
            Submit("logoutForm");
        }

        private void CompleteRegistrationForm(string userName, string password)
        {
            driver.Navigate().GoToUrl(root + "account/register");
            InputText(userName, "UserName");
            InputText(password, "Password");
            InputText(password, "ConfirmPassword");
            Submit("ConfirmPassword");
        }

        private void CompleteLogInForm(string userName, string password)
        {
            driver.Navigate().GoToUrl(root + "account/login");
            InputText(userName, "UserName");
            InputText(password, "Password");
            Submit("Password");
        }

        private void InputText(string value, string inputId)
        {
            var inputElement = driver.FindElement(By.Id(inputId));
            inputElement.SendKeys(value);
        }

        private void Submit(string inputId)
        {
            var inputElement = driver.FindElement(By.Id(inputId));
            inputElement.Submit();
        }
	}
}