using CafeMenu.Business.Constants;
using CafeMenu.Entities.Dtos;
using FluentValidation;

namespace CafeMenu.Business.ValidationRules.FluentValidation
{
    public class UserLoginValidator : AbstractValidator<UserForLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(Messages.UsernameIsNotEmpty);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordIsNotEmpty);
        }
    }
}
