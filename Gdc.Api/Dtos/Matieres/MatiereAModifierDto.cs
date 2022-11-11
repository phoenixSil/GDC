using Gdc.Api.Modeles;
using System.ComponentModel.DataAnnotations;

namespace Gdc.Api.Dtos.Matieres
{
    public class MatiereAModifierDto: BaseDto, IMatiereDto
    {
        [Required]
        public int NbreHeureInitiale { get; set; }

        [Required]
        public string CodeMatiere { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public double NoteDeValidation { get; set; }

        [Required]
        public Guid NiveauId { get; set; }

        [Required]
        public Guid CoursGeneriqueId { get; set; }
        public Guid EnseignantId { get; set; }
    }
}
