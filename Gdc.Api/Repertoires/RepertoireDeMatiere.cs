using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Datas;
using MsCommun.Repertoires;

namespace Gdc.Api.Repertoires
{
    public class RepertoireDeMatiere : RepertoireGenerique<Matiere>, IRepertoireDeMatiere
    {
        private readonly CourDbContext _context;
        public RepertoireDeMatiere(CourDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
