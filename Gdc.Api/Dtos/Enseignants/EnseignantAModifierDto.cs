using Gdc.Api.Modeles.Utils;
using System.ComponentModel.DataAnnotations;

namespace Gdc.Api.Dtos.Enseignants
{
    public class EnseignantAModifierDto : BaseDto, IEnseignantDto
    {
        [Required]
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [Required]
        public Guid NumeroExterne { get; set; }

        [Required]
        public SPECIALITE_ENSEIGNANT Specialite { get; set; }
        
        [Required]
        public NIVEAU_ETUDE Niveau { get; set; }
    }
}
