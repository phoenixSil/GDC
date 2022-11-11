using Gdc.Api.Dtos.Matieres;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class ModifierUneMatiereCmd : IRequest<ReponseDeRequette>
    {
        public Guid MatiereId { get; internal set; }
        public MatiereAModifierDto MatiereAModifierDto { get; internal set; }
    }
}
