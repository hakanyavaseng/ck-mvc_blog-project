using Microsoft.AspNetCore.Mvc;
using MVCBlog.Service.Services.Abstractions;

namespace MVCBlog.Web.ViewComponents
{
    public class HomeCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories =  await _categoryService.GetAllCategoriesTake24();
            return View(categories);
        }
    }
}
