using Gdc.Features.Contrats.Repertoires;

namespace Gdc.Features.Contrats.Repertoires
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
