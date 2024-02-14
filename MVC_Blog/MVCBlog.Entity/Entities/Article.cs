using MVCBlog.Core.Entities;
using MVCBlog.Entity.Entities.Identity;

namespace MVCBlog.Entity.Entities
{
    public class Article : EntityBase
	{
       
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        //Category
        public Guid CategoryId { get; set; } 
		public Category Category { get; set; }

        //Image
		public Guid? ImageId { get; set; } 
        public Image Image { get; set; }

        //User
        public Guid AppUserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> Visitors { get; set; }


        //Entity Constructor
        public Article()
        {

        }

        public Article(string title, string content, Guid userId, Guid categoryId, Guid imageId, string createdBy)
        {
            Title = title;
            Content = content;
            AppUserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
            CreatedBy = createdBy;
        }

    }
}
