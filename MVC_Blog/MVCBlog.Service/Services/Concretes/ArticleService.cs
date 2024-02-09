using AutoMapper;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Services.Abstractions;

namespace MVCBlog.Service.Services.Concretes
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			var userId = Guid.Parse("7893082F-7266-41F5-8E2C-D89989EE60D0");

			var article = new Article()
			{
				Title = articleAddDto.Title,
				Content = articleAddDto.Content,
				CategoryId = articleAddDto.CategoryId,
				AppUserId = userId
			};

			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
		}

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a =>a.IsDeleted==false,x=>x.Category);
			var map = _mapper.Map<List<ArticleDto>>(articles);
			return map;
		}
	}

}
