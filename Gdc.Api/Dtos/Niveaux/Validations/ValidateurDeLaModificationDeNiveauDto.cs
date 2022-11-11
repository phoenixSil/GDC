using FluentValidation;
using Gdc.Api.Dtos.Niveaux;
using Gdc.Api.Dtos.Niveaux.Validateurs;

namespace Gdc.Api.Dtos.Niveaux.Validations
{
    public class ValidateurDeLaModificationDeNiveauDto: AbstractValidator<NiveauAModifierDto>
    {
        public ValidateurDeLaModificationDeNiveauDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
 