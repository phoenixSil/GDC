using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Commandes.CoursGeneriques
{
    public class LireTousLesCoursGeneriquesCmd : BaseCommand<List<CoursGeneriqueDto>>
    {
    }
}
