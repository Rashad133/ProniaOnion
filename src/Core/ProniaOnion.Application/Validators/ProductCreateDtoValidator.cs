﻿using FluentValidation;
using ProniaOnion.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Validators
{
    internal class ProductCreateDtoValidator:AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Name is important")
                .MaximumLength(100).WithMessage("Name may contain maximum 100 characters").MinimumLength(2);

            RuleFor(x =>x.SKU).NotEmpty().MaximumLength(10);

            RuleFor(x => x.Price).NotEmpty()
                .LessThanOrEqualTo(999999.99m)
                .GreaterThanOrEqualTo(10);

                //.Must(x => x > 10 && x<999999.99m);--alternativ

            RuleFor(x => x.Description).MaximumLength(1000);

        }
    }
}
