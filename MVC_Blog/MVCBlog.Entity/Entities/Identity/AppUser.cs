using Microsoft.AspNetCore.Identity;
using MVCBlog.Core.Entities;

namespace MVCBlog.Entity.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ImageId { get; set; } = Guid.Parse("906D333C-201D-4B39-8E21-52A3ACC1FF73");
        public Image? Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
