using FluentValidation;
using VetProManager.Service.DTOs;

namespace VetProManager.Service.Validations {
    public class SpeciesValidator: AbstractValidator<SpeciesDto> {
        public SpeciesValidator()
        {
            //TODO: Code alanının unique olması gerekiyor eklenecek.
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tür adı boş geçilemez.");
            RuleFor(x => x.Code).NotNull().NotEmpty().WithMessage("Tür kodu boş geçilemez.");
        }

    }
}
