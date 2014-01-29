namespace SeleniumDemo.Tests.UI.Infrastructure
{
    public abstract class Page : Element, IPage
    {
        public string Title
        {
            get { return Driver.Title; }
        }
    }
}