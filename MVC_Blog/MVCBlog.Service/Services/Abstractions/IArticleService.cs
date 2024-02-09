using MVCBlog.Entity.Entities;

namespace MVCBlog.Service.Services.Abstractions
{
	public interface IArticleService
	{
		Task<List<Article>> GetAllArticlesAsync();
	}
}
