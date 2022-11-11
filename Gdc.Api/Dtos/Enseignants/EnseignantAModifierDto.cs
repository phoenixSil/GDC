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
    }
}
