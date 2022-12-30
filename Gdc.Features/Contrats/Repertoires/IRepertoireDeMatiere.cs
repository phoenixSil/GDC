using Gdc.Domain.Modeles;
using Gdc.Features.Dtos.Matieres;
using MsCommun.Repertoires.Contrats;

namespace Gdc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeMatiere : IRepertoireGenerique<Matiere>
    {
        public Task<Matiere> LireDetail(Guid id);
    }
}
