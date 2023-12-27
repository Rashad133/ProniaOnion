using FluentValidation;
using ProniaOnion.Application.DTOs.Users;

namespace ProniaOnion.Application.Validators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is important")
                .MaximumLength(256)
                .WithMessage("Maximum length 256 characters")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Minimum length 8")
                .MaximumLength(150)
                .WithMessage("Maximum length 150");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Maximum length 50")
                .MinimumLength(4)
                .WithMessage("Minimum length 4");
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Minimum length 3")
                .MaximumLength(50)
                .WithMessage("Maximum length 50");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Minimum length 3")
                .MaximumLength(50)
                .WithMessage("Maximum length 50");
            RuleFor(x => x).Must(x=>x.ConfirmPassword==x.Password);


        }
    }
}
