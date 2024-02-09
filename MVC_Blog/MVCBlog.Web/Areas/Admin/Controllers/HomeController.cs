using Microsoft.AspNetCore.Mvc;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
