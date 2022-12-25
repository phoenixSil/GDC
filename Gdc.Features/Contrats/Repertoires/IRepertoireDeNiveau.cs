using Gdc.Domain.Modeles;
using MsCommun.Repertoires.Contrats;

namespace Gdc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        Task<Niveau> LireParNumeroExterne(Guid numeroExterne);
    }
}
