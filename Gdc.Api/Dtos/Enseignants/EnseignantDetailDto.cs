using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Dtos.Programmations;
using Gdc.Api.Modeles;
using Gdc.Api.Modeles.Utils;

namespace Gdc.Api.Dtos.Enseignants
{
    public class EnseignantDetailDto: BaseDto, IEnseignantDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
        public SPECIALITE_ENSEIGNANT Specialite { get; set; }
        public NIVEAU_ETUDE Niveau { get; set; }
        public List<MatiereDto> Matieres { get; set; }
    }
}
