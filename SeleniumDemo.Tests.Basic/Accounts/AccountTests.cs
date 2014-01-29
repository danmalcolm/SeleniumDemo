using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemo.Tests.Basic.Shared;

namespace SeleniumDemo.Tests.Basic.Accounts
{
    /// <summary>
    /// Demonstrates how to write tests in simple unit test style with raw Selenium API. 
    /// 
    /// Note how we've managed to keep the code reasonably concise through the use of
    /// some simple helper methods. Common low-level methods like InputText are added
    /// to our test base class. More specific shared methods like CompleteLogInForm
    /// are added to the current test class. 
    /// 
    /// This wouldn't scale well to large number of tests or complex set of interactions,
    /// but it gives a good introduction to various aspects of working with Selenium.
    /// </summary>
	[TestFixture]
	public class AccountTests : UiTestBase
    {
		[Test]
		public void when_not_logged_in_should_be_redirected_to_login_screen()
		{
			Driver.Navigate().GoToUrl(Root);

			var uri = new Uri(Driver.Url);
			Assert.AreEqual("/Account/Login", uri.LocalPath);
		}

        [Test]
        public void after_registering_should_be_logged_in()
        {
            CompleteRegistrationForm("mike", "fluffybunnykins");

            var uri = new Uri(Driver.Url);
            Assert.AreEqual("/", uri.LocalPath, "Should redirect to home page");

            var info = Driver.FindElement(By.Id("login"));
            StringAssert.StartsWith("Hello, mike", info.Text, "Should display logged in status");
        }

        [Test]
        public void after_logging_in_should_be_logged_in()
        {
            CompleteRegistrationForm("mike", "fluffybunnykins");
            LogOut();
            CompleteLogInForm("mike", "fluffybunnykins");

            var uri = new Uri(Driver.Url);
            Assert.AreEqual("/", uri.LocalPath, "Should redirect to home page");

            var info = Driver.FindElement(By.Id("login"));
            StringAssert.StartsWith("Hello, mike", info.Text, "Should display logged in status");
        }

        private void LogOut()
        {
            SubmitForm("logoutForm");
        }

        private void CompleteRegistrationForm(string userName, string password)
        {
            GoToUrl("account/register");
            InputText(userName, "UserName");
            InputText(password, "Password");
            InputText(password, "ConfirmPassword");
            SubmitForm("ConfirmPassword");
        }

        private void CompleteLogInForm(string userName, string password)
        {
            GoToUrl("account/login");
            InputText(userName, "UserName");
            InputText(password, "Password");
            SubmitForm("Password");
        }
    }
}