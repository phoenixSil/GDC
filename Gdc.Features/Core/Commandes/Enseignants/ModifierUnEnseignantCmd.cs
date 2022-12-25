using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Core.BaseFactoryClass;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Features.Core.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid EnseignantId { get; set; }
        public EnseignantAModifierDto EnseignantAModifierDto { get; set; }
    }
}
