using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Validators
{
    public class ProductUpdateDtoValidator:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may contain maximum 100 characters").MinimumLength(2);

            RuleFor(x => x.SKU).NotEmpty().MaximumLength(10);

            RuleFor(x => x.Price).NotEmpty()
                .LessThanOrEqualTo(999999.99m)
                .GreaterThanOrEqualTo(10);

            //.Must(x => x > 10 && x<999999.99m);--alternativ

            RuleFor(x => x.Description).MaximumLength(1000);

            RuleFor(x => x.CategoryId).NotNull().NotEqual(0);

            RuleForEach(x => x.ColorIds).Must(c => c > 0);
            RuleFor(x => x.ColorIds).NotEmpty();
        }
    }
}
