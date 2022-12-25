using FluentValidation;
using Gdc.Features.Dtos.Matieres;

using Gdc.Features.Contrats.Repertoires;

namespace Gdc.Api.DTOs.Matieres.Validateurs
{
    public class ValidateurDeLaModificationDuneMatiereDto: AbstractValidator<MatiereAModifierDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaModificationDuneMatiereDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeMatiereDto(_pointDaccess));
        }
    }
}
 