using OpenQA.Selenium;

namespace SeleniumDemo.Tests.UI.Infrastructure
{
    /// <summary>
    /// Represents an entire HTML page
    /// </summary>
    public interface IPage : IElement
    {
        string Title { get; }
    }
}