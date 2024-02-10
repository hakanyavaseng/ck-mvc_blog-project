using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Web.ResultMessages;
using NToastNotify;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]

    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        private readonly IToastNotification _toast;
        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _toast = toastNotification;

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
            return View(new ArticleAddDto { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = _mapper.Map<Article>(articleAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _articleService.CreateArticleAsync(articleAddDto);
                _toast.AddSuccessToastMessage(Messages.Article.AddSuccess);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                _toast.AddErrorToastMessage(Messages.Article.AddError);
                result.AddToModelState(ModelState);

            }
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithCategoryNonDeletedAsync(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var map = _mapper.Map<Article>(articleUpdateDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _articleService.UpdateArticleAsync(articleUpdateDto);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid articleId)
        {
            await _articleService.SafeDeleteArticleAsync(articleId);

            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

    }

}
