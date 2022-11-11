using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Matieres
{
    public interface IMatiereDto
    {
        public int NbreHeureInitiale { get; set; }
        public string CodeMatiere { get; set; }
        public string Designation { get; set; }
        public double NoteDeValidation { get; set; }
        public Guid NiveauId { get; set; }
        public Guid CoursGeneriqueId { get; set; }

    }
}
