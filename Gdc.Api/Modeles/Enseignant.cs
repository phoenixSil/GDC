namespace Gdc.Api.Modeles
{
    public class Enseignant: BaseEntite
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Guid NumeroExterne { get; set; }
        public virtual List<Matiere> Matieres { get; set; }
    }
}
