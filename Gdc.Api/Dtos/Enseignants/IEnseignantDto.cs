using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Enseignants
{
    public interface IEnseignantDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
    }
}
