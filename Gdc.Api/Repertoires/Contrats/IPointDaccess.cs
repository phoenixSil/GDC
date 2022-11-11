using Gdc.Api.Repertoires.Contrats;

namespace Gdc.Api.Repertoires.Contrats
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDeMatiere RepertoireDeMatiere { get; }
        IRepertoireDenseignant RepertoireDenseignant { get; }
        IRepertoireDeNiveau RepertoireDeNiveau { get; }
        IRepertoireDeCoursGenerique RepertoireDeCoursGenerique { get; }
        Task Enregistrer();
    }
}
