using Gdc.Api.Dtos.Enseignants;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public Guid EnseignantId { get; internal set; }
        public EnseignantAModifierDto EnseignantAModifierDto { get; internal set; }
    }
}
