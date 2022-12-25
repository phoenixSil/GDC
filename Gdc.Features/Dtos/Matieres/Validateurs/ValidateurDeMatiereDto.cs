using FluentValidation;
using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Contrats.Repertoires;

namespace Gdc.Api.DTOs.Matieres.Validateurs
{
    public class ValidateurDeMatiereDto : AbstractValidator<IMatiereDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeMatiereDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(x => x.Designation)
             .NotEmpty()
             .MaximumLength(100)
             .NotNull();

            RuleFor(x => x.CodeMatiere)
             .NotEmpty()
             .Length(10)
             .NotNull();

            RuleFor(x => x.NbreHeureInitiale)
             .NotEmpty()
             .GreaterThan(0);

            RuleFor(x => x.NoteDeValidation)
             .NotEmpty()
             .GreaterThan(10);

            RuleFor(p => p.CoursGeneriqueId)
              .NotEmpty()
              .MustAsync(async (id, token) => {
                  var coursGeneriqueExists = await _pointDaccess.RepertoireDeCoursGenerique.Exists(id);
                  return coursGeneriqueExists;
              })
           .WithMessage($" le CoursGenerique nexiste pas dans la base de donnees  ");

            RuleFor(p => p.NiveauId)
               .NotEmpty()
               .MustAsync(async (id, token) => {
                   var niveauExists = await _pointDaccess.RepertoireDeNiveau.Exists(id);
                   return niveauExists;
               })
            .WithMessage($" le Niveau nexiste pas dans la base de donnees  ");
        }
    }
}
