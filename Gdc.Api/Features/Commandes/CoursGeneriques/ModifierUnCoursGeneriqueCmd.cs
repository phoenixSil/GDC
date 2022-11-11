using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class ModifierUnCoursGeneriqueCmd : IRequest<ReponseDeRequette>
    {
        public Guid CoursGeneriqueId { get; internal set; }
        public CoursGeneriqueAModifierDto CoursGeneriqueAModifierDto { get; internal set; }
    }
}
