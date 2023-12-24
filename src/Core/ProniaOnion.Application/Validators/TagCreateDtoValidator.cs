using FluentValidation;
using ProniaOnion.Application.DTOs.Tag;

namespace ProniaOnion.Application.Validators
{
    public class TagCreateDtoValidator:AbstractValidator<TagCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(2);
        }
    }
}
