using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Dtos.Programmations;
using Gdc.Domain.Modeles;
using Gdc.Domain.Modeles.Utils;

namespace Gdc.Features.Dtos.Enseignants
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
