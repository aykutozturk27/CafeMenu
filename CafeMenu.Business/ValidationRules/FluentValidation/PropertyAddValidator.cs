﻿using CafeMenu.Business.Constants;
using CafeMenu.Entities.Dtos;
using FluentValidation;

namespace CafeMenu.Business.ValidationRules.FluentValidation
{
    public class PropertyAddValidator : AbstractValidator<PropertyAddDto>
    {
        public PropertyAddValidator()
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage(Messages.PropertyKeyIsNotEmpty);
            RuleFor(x => x.Value).NotEmpty().WithMessage(Messages.PropertyValueIsNotEmpty);
        }
    }
}
