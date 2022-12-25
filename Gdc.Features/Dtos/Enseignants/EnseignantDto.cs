using Gdc.Domain.Modeles;
using Gdc.Domain.Modeles.Utils;

namespace Gdc.Features.Dtos.Enseignants
{
    public class EnseignantDto: BaseDto, IEnseignantDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
    }
}
