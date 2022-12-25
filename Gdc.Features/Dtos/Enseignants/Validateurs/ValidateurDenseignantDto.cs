using FluentValidation;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Dtos.Programmations;

namespace Gdc.Api.DTOs.Programmations.Validateurs
{
    public class ValidateurDenseignantDto : AbstractValidator<IEnseignantDto>
    {
        public ValidateurDenseignantDto()
        {
            RuleFor(x => x.Nom)
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(3);

            RuleFor(x => x.NumeroExterne)
                .NotNull();
        }
    }
}
