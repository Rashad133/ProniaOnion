using FluentValidation;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.Application.Validators
{
    public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
    {

        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(2).Matches(@"^[a-zA-Z\s]*$");

        }
    }
}
