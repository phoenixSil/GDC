using FluentValidation;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Api.DTOs.Programmations.Validateurs;

namespace Gdc.Features.Dtos.Programmations.Validateurs
{
    public class ValidateurDeLaCreationDunEnseignantDto : AbstractValidator<EnseignantACreerDto>
    {
        public ValidateurDeLaCreationDunEnseignantDto()
        {
            Include(new ValidateurDenseignantDto());
        }
    }
}
