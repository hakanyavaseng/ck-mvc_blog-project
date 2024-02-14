using MVCBlog.Entity.DTOs.Articles;
using System.Threading.Tasks;

namespace MVCBlog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleId);
        Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task SafeDeleteArticleAsync(Guid articleId);
        Task UndoDeleteArticleAsync(Guid articleId);
        //UI
        Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);
    }
}


