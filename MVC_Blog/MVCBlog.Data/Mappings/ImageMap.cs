using Microsoft.EntityFrameworkCore;
using MVCBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Data.Mappings
{
	public class ImageMap : IEntityTypeConfiguration<Image>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Image> builder)
		{
			//Data Seeding
			builder.HasData(
			new Image()
			{
				Id = Guid.Parse("906D333C-201D-4B39-8E21-52A3ACC1FF73"),
				FileName = "aspnetcore.jpg",
				FileType = "image/jpeg",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			},
			new Image()
			{
				Id = Guid.Parse("3EDBDE25-8F71-4834-AC2D-C1665C10BC63"),
				FileName = "entityframework.jpg",
				FileType = "image/jpeg",
				CreatedBy = "Admin",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			}
			);
			
		}
	}
}
