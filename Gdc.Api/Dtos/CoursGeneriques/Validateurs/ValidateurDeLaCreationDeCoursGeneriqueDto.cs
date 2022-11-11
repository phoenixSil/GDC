using FluentValidation;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Dtos.CoursGeneriques.Validateurs
{
    public class ValidateurDeLaCreationDeCoursGeneriqueDto:  AbstractValidator<CoursGeneriqueACreerDto>
    {
        public ValidateurDeLaCreationDeCoursGeneriqueDto()
        {
            Include(new ValidateurDeDtoDeCoursGenerique());
        }
    }
}
