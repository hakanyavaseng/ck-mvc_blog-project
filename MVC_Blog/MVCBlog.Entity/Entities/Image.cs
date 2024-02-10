using MVCBlog.Core.Entities;
using MVCBlog.Entity.Entities.Identity;

namespace MVCBlog.Entity.Entities
{
	public class Image : EntityBase
	{
        public Image()
        {
            
        }

        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }

        public Guid Id { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }

		//Article
		public ICollection<Article> Articles { get; set; }

		//AppUser
		public Guid AppUserId { get; set; }
		public ICollection<AppUser> Users { get; set; }

    }
}
