using Gdc.Api.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gdc.Api.Repertoires.Contrats
{
    public interface IRepertoireDenseignant : IRepertoireGenerique<Enseignant>
    {
        Task<bool> EnseignantExisteDejaParNumeroExterne(Guid NumeroExterne);
        Task<Enseignant?> LireEnseignantParNumeroExterne(Guid numeroExterne);
    }
}
