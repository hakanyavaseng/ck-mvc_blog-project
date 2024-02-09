using Microsoft.AspNetCore.Mvc;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using MVCBlog.Web.Models;
using System.Diagnostics;

namespace MVCBlog.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IArticleService _articleService;

		public HomeController(ILogger<HomeController> logger,IArticleService articleService)
		{
			_logger = logger;
			_articleService = articleService;
		}

		public async Task<IActionResult> Index()
		{
			var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();

			return View(articles);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
