using Microsoft.AspNetCore.Http;
using MVCBlog.Entity.DTOs.Categories;

namespace MVCBlog.Entity.DTOs.Articles
{
    public class ArticleAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Photo { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
