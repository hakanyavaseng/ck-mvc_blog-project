using Microsoft.EntityFrameworkCore;
using MVCBlog.Entity.Entities;
using System.Reflection;

namespace MVCBlog.Data.Contexts
{
	public class AppDbContext : DbContext
	{
		protected AppDbContext(){}

		//Options constructor
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//This method is checks all IEntityTypeConfiguration implementations in the assembly and applies them.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		//Entities
		public DbSet<Article> Articles { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Image> Images { get; set; }
	}
}
