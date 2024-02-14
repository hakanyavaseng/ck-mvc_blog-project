using MVCBlog.Core.Entities;

namespace MVCBlog.Entity.Entities
{
    public class ArticleVisitor : IEntityBase
    {
        public ArticleVisitor() { }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
    }
}

