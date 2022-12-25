using Gdc.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gdc.Features.Contrats.Repertoires
{
    public interface IRepertoireDenseignant : IRepertoireGenerique<Enseignant>
    {
        Task<bool> EnseignantExisteDejaParNumeroExterne(Guid NumeroExterne);
        Task<Enseignant?> LireEnseignantParNumeroExterne(Guid numeroExterne);
    }
}
