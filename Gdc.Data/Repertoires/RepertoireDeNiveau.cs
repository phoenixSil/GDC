using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using MsCommun.Repertoires;
using MsCommun.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;

namespace Gdc.Data.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        private readonly CourDbContext _context;

        public RepertoireDeNiveau(CourDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Niveau> LireParNumeroExterne(Guid numeroExterne)
        {
            var niveau = await _context.Niveaux
                    .SingleOrDefaultAsync(niv => niv.NumeroExterne == numeroExterne);

            return niveau;
        }
    }
}
