using MVCBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Entity.Entities
{
    public class Visitor : IEntityBase
    {
        public Visitor(string ipAddress,string userAgent) { }

        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }

        public ICollection<ArticleVisitor> Articles { get; set; }

       
    }
}
