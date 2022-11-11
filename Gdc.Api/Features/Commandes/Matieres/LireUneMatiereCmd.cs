using Gdc.Api.Dtos.Matieres;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class LireUneMatiereCmd : IRequest<MatiereDetailDto>
    {
        public Guid MatiereId { get; internal set; }
    }
}
