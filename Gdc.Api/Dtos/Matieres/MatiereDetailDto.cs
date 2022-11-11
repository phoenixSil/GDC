using Gdc.Api.Dtos.CoursGeneriques;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Dtos.Niveaux;
using Gdc.Api.Dtos.Programmations;
using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.Matieres
{
    public class MatiereDetailDto: IMatiereDto
    {
        public int NbreHeureInitiale { get; set; }
        public string CodeMatiere { get; set; }
        public string Designation { get; set; }
        public double NoteDeValidation { get; set; }
        public Guid NiveauId { get; set; }
        public NiveauDto Niveau { get; set; }
        public Guid CoursGeneriqueId { get; set; }
        public CoursGeneriqueDto CoursGenerique { get; set; }
        public Guid EnseignantId { get; set; }
        public EnseignantDto Enseignant { get; set; }
    }
}
