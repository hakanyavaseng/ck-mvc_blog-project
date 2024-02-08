using MVCBlog.Core.Entities;

namespace MVCBlog.Entity.Entities
{
	public class Image : EntityBase
	{
        public Guid Id { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public ICollection<Article> Articles { get; set; }
    }
}
