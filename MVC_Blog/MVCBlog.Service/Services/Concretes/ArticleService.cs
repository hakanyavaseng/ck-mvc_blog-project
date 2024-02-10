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
			var imageId = Guid.Parse("906D333C-201D-4B39-8E21-52A3ACC1FF73");

			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, articleAddDto.CategoryId, imageId);

			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
		}

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a =>a.IsDeleted==false,x=>x.Category);
			var map = _mapper.Map<List<ArticleDto>>(articles);
			return map;
		}

		public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId)
		{
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(a=>a.IsDeleted==false && a.Id==articleId,x=>x.Category);
			var map = _mapper.Map<ArticleDto>(article);
			return map;
		}

		public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(a => a.IsDeleted == false && a.Id == articleUpdateDto.Id, x => x.Category);


			//TODO : AutoMapper hata verdi o yüzden tekrar bak!
			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;


			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();

		}

		public async Task SafeDeleteArticleAsync(Guid articleId)
		{
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = "WILLBEDEFINED";

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }
	}

}
