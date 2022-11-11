using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Niveaux
{
    public class NiveauDto: BaseDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
