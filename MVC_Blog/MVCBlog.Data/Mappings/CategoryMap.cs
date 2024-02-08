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
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			//Data Seeding
			builder.HasData(
			new Category()
			{
				Id = Guid.Parse("E5129FA7-7CB3-421A-B6B8-DE983725A187"),
				Name = "ASP.Net Core",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Category()
			{
				Id = Guid.Parse("EFAF03FC-92EB-45D7-8980-7C75D5A5EA8C"),
				Name = "Entity Framework",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			});
			
		}
	}

}
