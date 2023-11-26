using FluentValidation;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Validations {
    public class SpeciesValidator: AbstractValidator<SpeciesDTO> {
        public SpeciesValidator()
        {
            //TODO: Code alanının unique olması gerekiyor eklenecek.
            RuleFor(x => x.Name).NotNull().WithMessage("Tür adı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Tür adı boş geçilemez.");
            RuleFor(x => x.Code).NotNull().WithMessage("Tür kodu boş geçilemez.");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Tür kodu boş geçilemez.");
        }

    }
}
