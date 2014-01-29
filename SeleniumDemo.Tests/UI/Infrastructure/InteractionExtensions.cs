using SampleSite.IntegrationTests.Interactions;

namespace SeleniumDemo.Tests.UI.Infrastructure
{
	public static class InteractionExtensions
	{
		/// <summary>
		/// Combines 2 interactions into a single interaction that executes the first, then the second
		/// </summary>
		/// <typeparam name="TStartPage"></typeparam>
		/// <typeparam name="TNextStartPage"></typeparam>
		/// <param name="previous"></param>
		/// <param name="next"></param>
		/// <returns></returns>
		public static IInteraction<TStartPage> Then<TStartPage, TNextStartPage>(this IInteraction<TStartPage> previous, IInteraction<TNextStartPage> next) 
			where TStartPage : IPage, new() 
			where TNextStartPage : IPage, new()
		{
			return new ChainedInteraction<TStartPage, TNextStartPage>(previous, next);
		}
	}
}