using Microsoft.AspNetCore.Identity;

namespace MVCBlog.Entity.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
