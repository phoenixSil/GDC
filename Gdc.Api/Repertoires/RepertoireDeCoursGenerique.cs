using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Api.Repertoires.Contrats;
using GDE.Api.Datas;
using MsCommun.Repertoires;

namespace Gdc.Api.Repertoires
{
    public class RepertoireDeCoursGenerique : RepertoireGenerique<CoursGenerique>, IRepertoireDeCoursGenerique
    {
        private readonly CourDbContext _context;
        public RepertoireDeCoursGenerique(CourDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
