using CafeMenu.Business.Constants;
using CafeMenu.Entities.Dtos;
using FluentValidation;

namespace CafeMenu.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage(Messages.CategoryNameIsNotEmpty);
        }
    }
}
