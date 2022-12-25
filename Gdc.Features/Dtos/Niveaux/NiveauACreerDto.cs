using System.ComponentModel.DataAnnotations;

namespace Gdc.Features.Dtos.Niveaux
{
    public class NiveauACreerDto : INiveauDto
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
