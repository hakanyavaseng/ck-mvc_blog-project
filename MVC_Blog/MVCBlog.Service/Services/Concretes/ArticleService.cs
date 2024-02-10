using AutoMapper;
using Microsoft.AspNetCore.Http;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Articles;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Extensions;
using MVCBlog.Service.Services.Abstractions;
using System.Security.Claims;

namespace MVCBlog.Service.Services.Concretes
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
			var userId = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();
			var imageId = Guid.Parse("906D333C-201D-4B39-8E21-52A3ACC1FF73");

			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, articleAddDto.CategoryId, imageId, userEmail);
			

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

		public async Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(a => a.IsDeleted == false && a.Id == articleUpdateDto.Id, x => x.Category);
            var userEmail = _user.GetLoggedInEmail();


            //TODO : AutoMapper hata verdi o yüzden tekrar bak!
            article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;
			article.ModifiedBy = userEmail;
			article.ModifiedDate = DateTime.Now;


			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();

		}

		public async Task SafeDeleteArticleAsync(Guid articleId)
		{
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            var userEmail = _user.GetLoggedInEmail();

            article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }
	}

}
