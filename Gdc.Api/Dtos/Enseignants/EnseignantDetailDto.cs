using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Dtos.Programmations;
using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Enseignants
{
    public class EnseignantDetailDto: BaseDto, IEnseignantDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
        public List<MatiereDto> Matieres { get; set; }
    }
}
