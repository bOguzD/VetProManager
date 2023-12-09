using FluentValidation;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Validations {
    public class UserValidator : AbstractValidator<UserDto> {

        public UserValidator() {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email adresi boş geçilemez.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Şifre boş geçilemez.");
        }

    }
}
