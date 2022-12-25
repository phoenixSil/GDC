using FluentValidation;
using Gdc.Features.Dtos.Niveaux.Validateurs;

namespace Gdc.Features.Dtos.Niveaux.Validations
{
    public class ValidateurDeLaCreationDeNiveauDto:  AbstractValidator<NiveauACreerDto >
    {
        public ValidateurDeLaCreationDeNiveauDto()
        {
            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
