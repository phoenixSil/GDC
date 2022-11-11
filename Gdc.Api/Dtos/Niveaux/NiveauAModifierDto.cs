using Gdc.Api.Dtos.Matieres;
using System.ComponentModel.DataAnnotations;

namespace Gdc.Api.Dtos.Niveaux
{
    public class NiveauAModifierDto: BaseDto, INiveauDto
    {
        [Required]
        public int ValeurCycle { get; set; }

        [Required]
        public string Designation { get; set; }
        
        [Required]
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
