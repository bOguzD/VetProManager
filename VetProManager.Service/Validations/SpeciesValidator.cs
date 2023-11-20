using FluentValidation;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Validations {
    public class SpeciesValidator: AbstractValidator<SpeciesDTO> {
        public SpeciesValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Tür adı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tür adı boş geçilemez.");
        }
    }
}
