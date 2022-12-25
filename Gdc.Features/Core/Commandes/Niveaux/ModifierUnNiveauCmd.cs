using MediatR;
using MsCommun.Reponses;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
