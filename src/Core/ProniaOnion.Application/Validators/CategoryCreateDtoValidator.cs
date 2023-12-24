using FluentValidation;
using ProniaOnion.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
