using System.Configuration;
using System.Web.Mvc;
using SeleniumDemo.WebApp.Filters;
using WebMatrix.WebData;

namespace SeleniumDemo.WebApp.Controllers.TestSupport
{
	/// <summary>
	/// Provides supporting functionality during automated UI tests
	/// </summary>
    [InitializeSimpleMembership]
	public class TestSupportController : Controller
	{
		/// <summary>
		/// Clears the current session and signs out
		/// </summary>
		/// <returns></returns>
		public ActionResult Reset()
		{
			if (ConfigurationManager.AppSettings["EnableTestSupportActions"] == "true")
			{
				Session.Abandon();
				Response.Cookies.Clear();
				WebSecurity.Logout();
                return Content("OK");
			} 
			else
			{
				return this.HttpNotFound();
			}
		}
	}
}