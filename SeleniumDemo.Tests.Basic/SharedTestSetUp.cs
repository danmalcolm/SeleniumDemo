using NUnit.Framework;
using SeleniumDemo.Tests.Basic.Shared;

namespace SeleniumDemo.Tests.Basic
{
    [SetUpFixture]
    public class MySetUpClass
    {
        [TearDown]
        public void RunAfterAllTests()
        {
            WebDriverStore.ResetDriver();
        }
    }
}