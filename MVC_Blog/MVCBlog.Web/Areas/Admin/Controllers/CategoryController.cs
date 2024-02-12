using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Entity.DTOs.Categories;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Extensions;
using MVCBlog.Service.Services.Abstractions;
using NToastNotify;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper, IToastNotification toastNotification)
        {
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;
            
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if(result.IsValid)
            {
                await _categoryService.AddCategory(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Category.AddSuccess);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            else
            {
                _toastNotification.AddErrorToastMessage(ResultMessages.Messages.Category.AddError);
                result.AddToModelState(ModelState);
                return View(categoryAddDto);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
        {
            var map = _mapper.Map<Category>(categoryAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.AddCategory(categoryAddDto);
                _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Category.AddSuccess);
                return Json(ResultMessages.Messages.Category.AddSuccess);
            }
            else
            {
                result.AddToModelState(ModelState);
                return Json(ResultMessages.Messages.Category.AddError);
            }            
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
            return View(categoryUpdateDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = _mapper.Map<Category>(categoryUpdateDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(categoryUpdateDto);
                _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Category.UpdateSuccess);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            else
            {
                _toastNotification.AddErrorToastMessage(ResultMessages.Messages.Category.UpdateError);
                result.AddToModelState(ModelState);
                return View(categoryUpdateDto);
            }
            
        }

        public async Task<IActionResult> Delete(Guid categoryId)
        {
            await _categoryService.SafeDeleteCategory(categoryId);
            _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Category.DeleteSuccess);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await _categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }

        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            await _categoryService.UndoDeleteCategoryAsync(categoryId);
            _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.Category.UndoDeleteSuccess);
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }


    }
}
