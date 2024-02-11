using MVCBlog.Core.Entities;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Entity.Enums;

namespace MVCBlog.Entity.Entities
{
	public class Image : EntityBase
	{
        public Image()
        {
            Users = new HashSet<AppUser>();
        }

        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
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
