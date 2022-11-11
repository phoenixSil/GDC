using FluentValidation;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Dtos.Programmations;

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
