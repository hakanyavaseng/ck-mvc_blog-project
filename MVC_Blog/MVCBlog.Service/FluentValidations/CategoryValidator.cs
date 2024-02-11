using FluentValidation;
using MVCBlog.Entity.Entities;

namespace MVCBlog.Service.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithName("Kategori Adı");
        }
    }
}
