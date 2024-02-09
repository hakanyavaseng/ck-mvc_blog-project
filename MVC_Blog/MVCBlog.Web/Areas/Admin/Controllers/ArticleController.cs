using Microsoft.AspNetCore.Mvc;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Service.Services.Abstractions;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]

    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            
            await _articleService.CreateArticleAsync(articleAddDto);
            RedirectToAction("Index", "Article", new {Area= "Admin"});

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });

        }

    }

}
