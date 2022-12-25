using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using MsCommun.Repertoires;

namespace Gdc.Data.Repertoires
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
