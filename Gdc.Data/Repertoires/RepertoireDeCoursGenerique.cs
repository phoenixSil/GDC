using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using MsCommun.Repertoires;

namespace Gdc.Data.Repertoires
{
    public class RepertoireDeCoursGenerique : RepertoireGenerique<CoursGenerique>, IRepertoireDeCoursGenerique
    {
        public RepertoireDeCoursGenerique(CourDbContext context) : base(context)
        {
        }
    }
}
