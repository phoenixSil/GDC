using FluentValidation;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Dtos.CoursGeneriques.Validateurs
{
    public class ValidateurDeLaModificationDeCoursGeneriqueDto: AbstractValidator<CoursGeneriqueAModifierDto>
    {
        public ValidateurDeLaModificationDeCoursGeneriqueDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeCoursGenerique());
        }
    }
}
 