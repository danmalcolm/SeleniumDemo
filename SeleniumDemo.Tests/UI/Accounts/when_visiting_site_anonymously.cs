using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemo.Tests.UI.Infrastructure;

namespace SeleniumDemo.Tests.UI.Accounts
{
    [TestFixture]
    public class UiTestContext
    {
        protected readonly string Root = ConfigurationManager.AppSettings["UiTesting.WebSiteRoot"];
        protected IWebDriver Driver;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Driver = new ChromeDriver("..\\..\\..\\Tools\\chromedriver_win_23.0.1240.0\\");
            Driver.Navigate().GoToUrl(Root + "testsupport/reset");
            var page = new AnyPage();
            page.Init(Driver);
            When(page);
        }

        protected virtual void When(AnyPage page)
        {
            
        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            Driver.Quit();
        }

        [SetUp]
        public void Setup()
        {
            // Reset everything
            
        }

        [TearDown]
        public void Teardown()
        {

        }
    }

    public class when_visiting_site_anonymously : UiTestContext
    {
        protected override void When(AnyPage page)
        {
            page.NavigateToHomePage();
        }

        [Test]
		public void should_be_redirected_to_login_page()
		{
			Driver.Navigate().GoToUrl(Root);

			var uri = new Uri(Driver.Url);
			Assert.AreEqual("/Account/Login", uri.LocalPath);
		}



    }
}