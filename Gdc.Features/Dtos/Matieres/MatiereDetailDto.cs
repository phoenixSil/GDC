using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Dtos.Programmations;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Dtos.Matieres
{
    public class MatiereDetailDto: IMatiereDto
    {
        public Guid Id { get; set; }
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
