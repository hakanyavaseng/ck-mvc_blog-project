using FluentValidation;
using MVCBlog.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");

            RuleFor(x => x.LastName)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Soyisim");

            RuleFor(x=>  x.PhoneNumber)
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(15)
                .WithName("Telefon Numarası");
                
            
        }








    }
}
