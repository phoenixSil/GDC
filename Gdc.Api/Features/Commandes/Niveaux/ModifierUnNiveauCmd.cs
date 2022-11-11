using MediatR;
using MsCommun.Reponses;
using Gdc.Api.Dtos.Niveaux;

namespace Gdc.Api.Features.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
