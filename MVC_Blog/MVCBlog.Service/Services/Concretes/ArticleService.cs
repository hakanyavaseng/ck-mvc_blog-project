using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.Entities;
using MVCBlog.Service.Services.Abstractions;

namespace MVCBlog.Service.Services.Concretes
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArticleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<Article>> GetAllArticlesAsync()
		{
			return await _unitOfWork.GetRepository<Article>().GetAllAsync();
		}
	}

}
