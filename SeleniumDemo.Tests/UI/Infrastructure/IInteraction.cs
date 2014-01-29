namespace SeleniumDemo.Tests.UI.Infrastructure
{
	public interface IInteraction<in TPage>
		where TPage : IPage
	{
		void Execute(TPage startPage);
	}
}