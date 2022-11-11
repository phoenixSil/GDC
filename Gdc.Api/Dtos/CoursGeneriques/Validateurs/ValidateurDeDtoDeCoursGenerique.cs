using FluentValidation;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Dtos.CoursGeneriques.Validateurs
{
    public class ValidateurDeDtoDeCoursGenerique: AbstractValidator<ICoursGeneriqueDto>
    {
        public ValidateurDeDtoDeCoursGenerique()
        {
            RuleFor(x => x.Designation)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100)
                .WithMessage("la Designation que vous avez entrer est incorrect ");

        }
    }
}
