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

		public async Task<List<ArticleDto>> GetAllArticlesAsync()
		{
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();
			var map = _mapper.Map<List<ArticleDto>>(articles);
			return map;
		}
	}

}
