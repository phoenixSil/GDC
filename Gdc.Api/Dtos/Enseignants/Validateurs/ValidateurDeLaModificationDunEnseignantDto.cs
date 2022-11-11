using FluentValidation;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Dtos.Programmations;

namespace Gdc.Api.DTOs.Programmations.Validateurs
{
    public class ValidateurDeLaModificationDunEnseignantDto: AbstractValidator<EnseignantAModifierDto>
    {        
        public ValidateurDeLaModificationDunEnseignantDto()
        {
            RuleFor(p => p.Id).NotNull()
               .NotEmpty()
               .WithMessage("Id doit pas etre null");

            Include(new ValidateurDenseignantDto());
        }
    }
}
 