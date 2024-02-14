using Microsoft.AspNetCore.Mvc;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using MVCBlog.Web.Models;
using System.Diagnostics;

namespace MVCBlog.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IArticleService _articleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IArticleService articleService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
		{
			_logger = logger;
			_articleService = articleService;
			_httpContextAccessor = httpContextAccessor;
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			var articles = await _articleService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);

			return View(articles);
		}

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);

            return View(articles);
        }

		public async Task<IActionResult> Detail(Guid id)
		{
			var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
			var articleVisitors = await _unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, v => v.Visitor, a => a.Article);

			Article article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id);
			ArticleDto resultArticle = await _articleService.GetArticleWithCategoryNonDeletedAsync(id);
			Visitor visitor = await _unitOfWork.GetRepository<Visitor>().GetAsync(v=>v.IpAddress == ipAddress);

			var newArticleVisitor = new ArticleVisitor
			{
				ArticleId = article.Id,
				VisitorId = visitor.Id,
			};

			if (articleVisitors.Any(x => x.VisitorId == newArticleVisitor.VisitorId && x.ArticleId == newArticleVisitor.ArticleId))
				return View(resultArticle);
			else
			{
				await _unitOfWork.GetRepository<ArticleVisitor>().AddAsync(newArticleVisitor);
				article.ViewCount += 1;
				await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
				await _unitOfWork.SaveAsync();
				return View(resultArticle);
			}


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
