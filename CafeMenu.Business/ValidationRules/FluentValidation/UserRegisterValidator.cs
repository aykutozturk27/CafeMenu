using CafeMenu.Business.Constants;
using CafeMenu.Entities.Dtos;
using FluentValidation;

namespace CafeMenu.Business.ValidationRules.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Messages.NameIsNotEmpty);
            RuleFor(x => x.SurName).NotEmpty().WithMessage(Messages.SurnameIsNotEmpty);
            RuleFor(x => x.Username).NotEmpty().WithMessage(Messages.UsernameIsNotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordIsNotEmpty);
        }
    }
}
