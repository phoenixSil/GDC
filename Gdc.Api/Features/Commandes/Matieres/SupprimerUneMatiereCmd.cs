using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class SupprimerUneMatiereCmd : IRequest<ReponseDeRequette>
    {
        public Guid MatiereId { get; internal set; }
    }
}
