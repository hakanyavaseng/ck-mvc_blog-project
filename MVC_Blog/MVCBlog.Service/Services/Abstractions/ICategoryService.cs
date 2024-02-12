using MVCBlog.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task AddCategory(CategoryAddDto categoryAddDto);
        Task<CategoryDto> GetCategoryById(Guid categoryId);
        Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task SafeDeleteCategory(Guid categoryId);

        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task UndoDeleteCategoryAsync(Guid categoryId);

    }
}
