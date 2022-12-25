using FluentValidation;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Dtos.Niveaux.Validateurs;

namespace Gdc.Features.Dtos.Niveaux.Validations
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
 