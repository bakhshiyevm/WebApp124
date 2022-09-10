using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Security.Claims;

namespace Presentation.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserService _userService;

		public LoginController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		[Route("SignIn")]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		[Route("SignIn")]
		public IActionResult SignIn(UserDTO user)
		{
			try
			{
				var res = _userService.Login(user);

				//var roles = _userService.GetUserRoles(res);
				Authenticate(res,null);
				return RedirectToAction( "Home","Main");
			}
			catch (Exception e)
			{
				return Unauthorized(e.Message);
			}

		}


		private  void  Authenticate(UserDTO user, IEnumerable<UserRoleDTO> userRole)
		{
			var claims = new List<Claim>
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("Username", user.Username),
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Surname, user.Surname),

			};

   //         foreach (var item in userRole)
   //         {

			//	claims.Add(
			//		new Claim(ClaimTypes.Role, item.RoleName)
			//				);
			//}


			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");
			
			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}

		[HttpGet]
		[Route("SignOut")]
		public IActionResult SignOut()
		{
			HttpContext.SignOutAsync();
			return RedirectToAction("SignIn");
		}

		[HttpGet]
		[Route("SignUp")]
		public IActionResult SignUp()
		{
			return View();
		}


		[HttpPost]
		[Route("SignUp")]
		public IActionResult SignUp(UserDTO user)
		{

			var x = Convert.ToInt32(HttpContext.User?.FindFirst(x => x.Type == "Id")?.Value);
			
			var res = _userService.Create(user);
			return View(res);
		}
	}
}
