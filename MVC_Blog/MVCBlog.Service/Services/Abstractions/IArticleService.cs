using MVCBlog.Entity.DTOs.Articles;

namespace MVCBlog.Service.Services.Abstractions
{
    public interface IArticleService
	{
		Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
	}
}


