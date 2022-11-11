using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Enseignants
{
    public class EnseignantDto: BaseDto, IEnseignantDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
    }
}
