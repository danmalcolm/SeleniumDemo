using OpenQA.Selenium;

namespace SeleniumDemo.Tests.UI.Infrastructure
{
    /// <summary>
    /// Represents a content element, section, control or entire page
    /// </summary>
    public interface IElement
    {
        void Init(IWebDriver driver);

        IWebDriver Driver { get; }
    }
}