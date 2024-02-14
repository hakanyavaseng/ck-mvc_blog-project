using AutoMapper;
using Microsoft.AspNetCore.Http;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Categories;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Extensions;
using MVCBlog.Service.Services.Abstractions;
using System.Security.Claims;

namespace MVCBlog.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
         
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(Category => Category.IsDeleted == false);
            var mapped = _mapper.Map<List<CategoryDto>>(categories);

            return mapped;
        }

        public async Task AddCategory(CategoryAddDto categoryAddDto)
        {

            //TODO Mapper ile tekrardan düzenlenecek!
            //var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            Category category = new Category(categoryAddDto.Name, userEmail);

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryDto> GetCategoryById(Guid categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            var mapped = _mapper.Map<CategoryDto>(category);
            return mapped; 

        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryUpdateDto.Id);
            var userEmail = _user.GetLoggedInEmail();

            category.Name = categoryUpdateDto.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

        }

        public async Task SafeDeleteCategory(Guid categoryId)
        {
            var userEmail = _user.GetLoggedInEmail();

            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(Category => Category.IsDeleted == true);
            var mapped = _mapper.Map<List<CategoryDto>>(categories);

            return mapped;


        }

        public async Task UndoDeleteCategoryAsync(Guid categoryId)
        {

            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
        }

        //UI
        public async Task<List<CategoryDto>> GetAllCategoriesTake24()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(Category => Category.IsDeleted == false);
            var mapped = _mapper.Map<List<CategoryDto>>(categories);
          


            return mapped.Take(24).ToList();
        }
    }
}
