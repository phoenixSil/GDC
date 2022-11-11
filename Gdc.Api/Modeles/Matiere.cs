namespace Gdc.Api.Modeles
{
    public class Matiere: BaseEntite
    {
        public int NbreHeureInitiale { get; set; }
        public string CodeMatiere { get; set; }
        public string Designation { get; set; }
        public double NoteDeValidation { get; set; }
        public Guid NiveauId { get; set; }
        public virtual Niveau Niveau { get; set; }
        public Guid CoursGeneriqueId { get; set; }
        public virtual CoursGenerique CoursGenerique { get; set; }
        public Guid EnseignantId { get; set; }
        public virtual Enseignant Enseignant { get; set; }

    }
}
