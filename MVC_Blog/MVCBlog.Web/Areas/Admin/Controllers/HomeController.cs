using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Entity.Entities.Identity;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Authorize]
	[Area(nameof(Admin))]
	public class HomeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        public HomeController(UserManager<AppUser> userManager)
        {
			_userManager = userManager;
            
        }
        public async Task<IActionResult> Index()
		{
			var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);


			return View();
		}
	}
}
