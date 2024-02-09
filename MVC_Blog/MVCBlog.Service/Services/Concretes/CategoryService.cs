using AutoMapper;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Categories;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(Category => Category.IsDeleted == false);
            var mapped = _mapper.Map<List<CategoryDto>>(categories);

            return mapped;
        }
    }
}
