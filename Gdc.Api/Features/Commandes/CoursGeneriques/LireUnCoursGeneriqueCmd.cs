using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class LireUnCoursGeneriqueCmd : IRequest<CoursGeneriqueDetailDto>
    {
        public Guid CoursGeneriqueId { get; internal set; }
    }
}
