using Microsoft.EntityFrameworkCore;
using MVCBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Data.Contexts
{
	public class AppDbContext : DbContext
	{
		protected AppDbContext(){}

		//Options constructor
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		//Entities
		public DbSet<Article> Articles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}
