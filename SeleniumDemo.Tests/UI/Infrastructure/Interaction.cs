using System;

namespace SeleniumDemo.Tests.UI.Infrastructure
{
	public class Interaction<TPage> : IInteraction<TPage>
		where TPage : IPage
	{
		private readonly Action<TPage> action;

		public Interaction(Action<TPage> action)
		{
			this.action = action;
		}

		public void Execute(TPage page)
		{
			action(page);
		}
	}
}