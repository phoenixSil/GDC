using Gdc.Domain.Modeles;

namespace Gdc.Features.Dtos.Matieres
{
    public class MatiereDto: BaseDto, IMatiereDto
    {
        public int NbreHeureInitiale { get; set; }
        public string CodeMatiere { get; set; }
        public string Designation { get; set; }
        public double NoteDeValidation { get; set; }
        public Guid NiveauId { get; set; }
        public Guid CoursGeneriqueId { get; set; }
    }
}
