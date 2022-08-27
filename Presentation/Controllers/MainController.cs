using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class MainController : Controller
	{
		[HttpGet]
		[Route("Home")]
		public ActionResult Home()
		{
			return View();
		}

	}
}
