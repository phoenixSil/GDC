using FluentValidation;
using Gdc.Api.DTOs.Matieres.Validateurs;

using Gdc.Features.Contrats.Repertoires;

namespace Gdc.Features.Dtos.Matieres.Validateurs
{
    public class ValidateurDeLaCreationDuneMatiereDto : AbstractValidator<MatiereACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDuneMatiereDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            Include(new ValidateurDeMatiereDto(_pointDaccess));
        }
    }
}
