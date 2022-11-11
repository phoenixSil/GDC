
using Gdc.Api.Modeles;
using Gdc.Api.Dtos;
using Gdc.Api.Dtos.Matieres;

namespace Gdc.Api.Dtos.Niveaux
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
