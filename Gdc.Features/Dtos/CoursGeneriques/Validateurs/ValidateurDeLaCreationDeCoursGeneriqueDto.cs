using FluentValidation;
using Gdc.Features.Dtos.CoursGeneriques;

namespace Gdc.Features.Dtos.CoursGeneriques.Validateurs
{
    public class ValidateurDeLaCreationDeCoursGeneriqueDto:  AbstractValidator<CoursGeneriqueACreerDto>
    {
        public ValidateurDeLaCreationDeCoursGeneriqueDto()
        {
            Include(new ValidateurDeDtoDeCoursGenerique());
        }
    }
}
