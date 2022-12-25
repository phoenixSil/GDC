using Gdc.Features.Dtos.Matieres;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Dtos.Niveaux
{
    public class NiveauDto: BaseDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
