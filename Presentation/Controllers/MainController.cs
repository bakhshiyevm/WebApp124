using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    //[Authorize]
	public class MainController : Controller
	{
		[HttpGet]
		[Route("Home")]
		public ActionResult Home()
		{
			ViewBag.Name = "Murad";
			ViewBag.Time = 123;

			ViewData["qrup"] = 124;

			return View();
		}

	}
}
