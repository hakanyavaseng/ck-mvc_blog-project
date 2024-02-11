using Microsoft.AspNetCore.Http;
using MVCBlog.Entity.DTOs.Categories;
using MVCBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Entity.DTOs.Articles
{
    public class ArticleUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public IFormFile? Photo { get; set; }
        public Image Image { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
