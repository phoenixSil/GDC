using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Commandes.CoursGeneriques
{
    public class LireUnCoursGeneriqueCmd : BaseCommand<CoursGeneriqueDetailDto>
    {
        public Guid CoursGeneriqueId { get; set; }
    }
}
