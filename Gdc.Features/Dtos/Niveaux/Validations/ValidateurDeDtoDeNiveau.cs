using FluentValidation;
using Gdc.Features.Dtos.Niveaux;

namespace Gdc.Features.Dtos.Niveaux.Validateurs
{
    public class ValidateurDeDtoDeNiveau: AbstractValidator<INiveauDto>
    {
        public ValidateurDeDtoDeNiveau()
        {
            RuleFor(x => x.Designation)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100)
                .WithMessage("la Designation que vous avez entrer est incorrect ");

            RuleFor(x => x.ValeurCycle)
               .NotEmpty()
               .GreaterThanOrEqualTo(1)
               .LessThanOrEqualTo(6);
        }
    }
}
