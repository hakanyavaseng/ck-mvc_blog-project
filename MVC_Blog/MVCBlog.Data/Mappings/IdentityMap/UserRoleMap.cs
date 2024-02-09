using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Data.Mappings.IdentityMap
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(
             new AppUserRole()
             {
                 UserId = Guid.Parse("7893082F-7266-41F5-8E2C-D89989EE60D0"),
                 RoleId = Guid.Parse("930FE77E-F06F-4FA1-A1E1-1BE271CE4990")

             },
             new AppUserRole()
             {
                 UserId = Guid.Parse("84CCAF88-5507-4DBF-8DDD-8F607DB51F0A"),
                 RoleId = Guid.Parse("903E68E3-C5BE-429A-8CCC-50699A0F8BAE")
             });
        }
    }
}
