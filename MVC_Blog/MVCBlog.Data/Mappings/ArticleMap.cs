using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Data.Mappings
{
	public class ArticleMap : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			//Constraints
			builder.Property(a => a.Title).HasMaxLength(100);
			builder.Property(a => a.Content).HasMaxLength(2000);

			//Data Seeding
			builder.HasData(
			new Article()
			{
				Id = Guid.NewGuid(),
				Title = "ASP.NET Core Article 1",
				Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. 
							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. 
							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. 
							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.",
				ViewCount = 15,
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				CategoryId = Guid.Parse("E5129FA7-7CB3-421A-B6B8-DE983725A187"),
				ImageId = Guid.Parse("906D333C-201D-4B39-8E21-52A3ACC1FF73"),
				IsDeleted = false
			},
			new Article()
			{
				Id = Guid.NewGuid(),
				Title = "Entity Framework Article 2",
				Content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. 
							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. 
							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. 
							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.",
				ViewCount = 25,
				CreatedBy = "User",
				CreatedDate = DateTime.Now,
				CategoryId = Guid.Parse("EFAF03FC-92EB-45D7-8980-7C75D5A5EA8C"),
				ImageId = Guid.Parse("3EDBDE25-8F71-4834-AC2D-C1665C10BC63"),
				IsDeleted = false
			}
			);

		}
	}
}
