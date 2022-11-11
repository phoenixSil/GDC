using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class SupprimerUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EnseignantId { get; internal set; }
    }
}
