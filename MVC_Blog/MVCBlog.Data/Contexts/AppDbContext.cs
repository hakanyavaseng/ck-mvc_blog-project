using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Entity.Entities;
using MVCBlog.Entity.Entities.Identity;
using System.Reflection;

namespace MVCBlog.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        protected AppDbContext() { }

        //Options constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //This method checks all IEntityTypeConfiguration implementations in the assembly and applies them.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //Entities
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors { get; set; }

    }
}
