using Microsoft.AspNetCore.Mvc;
using MVCBlog.Service.Services.Abstractions;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]

    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
    }
}
