using Gdc.Domain.Modeles;
using System.ComponentModel.DataAnnotations;

namespace Gdc.Features.Dtos.Matieres
{
    public class MatiereACreerDto: IMatiereDto
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
