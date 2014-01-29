using System;
using OpenQA.Selenium;
using SeleniumDemo.Tests.UI.Infrastructure;

namespace SampleSite.IntegrationTests.Interactions
{
	public class ChainedInteraction<TStartPage,TStartPageForNextInteraction> : IInteraction<TStartPage>
		where TStartPage : IPage, new()
		where TStartPageForNextInteraction : IPage, new()
	{
		private readonly IInteraction<TStartPage> _previous;
		private readonly IInteraction<TStartPageForNextInteraction> _next;

		public ChainedInteraction(IInteraction<TStartPage> previous, IInteraction<TStartPageForNextInteraction> nextInteraction)
		{
			_previous = previous;
			_next = nextInteraction;
		}

		public void Execute(TStartPage startPage)
		{
			_previous.Execute(startPage);
			var intermediatePage = GetIntermediatePage(startPage.Browser);
			_next.Execute(intermediatePage);
		}

        private TStartPageForNextInteraction GetIntermediatePage(IWebDriver selenium)
		{
			var page = new PageFactory().GetPageOrDefault(selenium);
			if (page == null)
			{
				string message =
					string.Format(
						"Unable to execute the next interaction in the sequence because the page type could not be identified from the url {0}. Tests rely on the PageFactory class to be able to determine what page the browser is on. Does PageFactory need some logic to identify the expected page type from the url?",
						selenium.GetLocation());
				throw new ApplicationException(message);
			}
			if (!typeof(TStartPageForNextInteraction).IsAssignableFrom(page.GetType()))
			{
				string message = string.Format(
@"Unable to execute the next interaction in the sequence because the browser was not on the expected page. 
Expected page type: {0}
Actual page type: {1}
Browser url: {2}", typeof(TStartPageForNextInteraction), page.GetType(), selenium.GetLocation());
				throw new ApplicationException(message);
			}
			return new TStartPageForNextInteraction { Browser = selenium };
		}
	}
}