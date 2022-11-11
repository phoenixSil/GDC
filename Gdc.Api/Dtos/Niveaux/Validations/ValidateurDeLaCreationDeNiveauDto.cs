using FluentValidation;
using Gdc.Api.Dtos.Niveaux.Validateurs;

namespace Gdc.Api.Dtos.Niveaux.Validations
{
    public class ValidateurDeLaCreationDeNiveauDto:  AbstractValidator<NiveauGdcACreerDto >
    {
        public ValidateurDeLaCreationDeNiveauDto()
        {
            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
