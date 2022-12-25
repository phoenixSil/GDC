
using Gdc.Domain.Modeles;

using Gdc.Features.Dtos.Matieres;

namespace Gdc.Features.Dtos.Niveaux
{
    public class NiveauDetailDto: BaseDto, INiveauDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
        public virtual List<MatiereDto> Matieres { get; set; }
    }
}
