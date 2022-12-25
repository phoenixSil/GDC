namespace Gdc.Domain.Modeles
{
    public class Niveau: BaseEntite
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
        public virtual List<Matiere> Matieres { get; set; }
    }
}
