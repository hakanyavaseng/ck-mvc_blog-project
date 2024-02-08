using MVCBlog.Core.Entities;

namespace MVCBlog.Entity.Entities
{
	public class Category : EntityBase, IEntityBase
	{
		public string Name { get; set; }
		public ICollection<Article> Articles { get; set; }

	}
}
