namespace Gdc.Api.Modeles
{
    public class CoursGenerique: BaseEntite
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public virtual List<Matiere> Matieres { get; set; }
    }
}
