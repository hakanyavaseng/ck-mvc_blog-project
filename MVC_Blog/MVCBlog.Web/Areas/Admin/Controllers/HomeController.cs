using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using Newtonsoft.Json;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Authorize]
	[Area(nameof(Admin))]
	public class HomeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        private readonly IDashboardService _dashboardService;

        public HomeController(UserManager<AppUser> userManager, IDashboardService dashboardService)
        {
			_userManager = userManager;
			_dashboardService = dashboardService;
            
        }
        public async Task<IActionResult> Index()
		{
			var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);


			return View();
		}

        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await _dashboardService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await _dashboardService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalCategoryCount()
        {
            var count = await _dashboardService.GetTotalCategoryCount();
            return Json(count);
        }

    }
}
