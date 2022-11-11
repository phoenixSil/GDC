using FluentValidation;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.DTOs.Programmations.Validateurs;

namespace Gdc.Api.Dtos.Programmations.Validateurs
{
    public class ValidateurDeLaCreationDunEnseignantDto : AbstractValidator<EnseignantACreerDto>
    {
        public ValidateurDeLaCreationDunEnseignantDto()
        {
            Include(new ValidateurDenseignantDto());
        }
    }
}
