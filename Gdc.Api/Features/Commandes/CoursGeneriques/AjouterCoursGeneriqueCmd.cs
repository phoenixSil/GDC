using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class AjouterCoursGeneriqueCmd : IRequest<ReponseDeRequette>
    {
        public CoursGeneriqueACreerDto CoursGeneriqueAAjouterDto { get; internal set; }
    }
}
