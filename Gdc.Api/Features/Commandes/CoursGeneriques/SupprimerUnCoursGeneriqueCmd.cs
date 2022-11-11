using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class SupprimerUnCoursGeneriqueCmd : IRequest<ReponseDeRequette>
    {
        public Guid CoursGeneriqueId { get; internal set; }
    }
}
