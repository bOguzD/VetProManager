using FluentValidation;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Validations {
    public class AuthTokenValidator : AbstractValidator<AuthTokenDto> {
        public AuthTokenValidator() {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email adresi boş geçilemez.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Şifre boş geçilemez.");
        }
    }
}
}
