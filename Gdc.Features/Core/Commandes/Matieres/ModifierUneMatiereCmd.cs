using Gdc.Features.Dtos.Matieres;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.Matieres
{
    public class ModifierUneMatiereCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid MatiereId { get; set; }
        public MatiereAModifierDto MatiereAModifierDto { get; set; }
    }
}
