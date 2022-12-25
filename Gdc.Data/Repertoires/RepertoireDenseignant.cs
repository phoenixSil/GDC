using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Gdc.Data.Repertoires
{
    public class RepertoireDenseignant : RepertoireGenerique<Enseignant>, IRepertoireDenseignant
    {
        private readonly CourDbContext _context;
        public RepertoireDenseignant(CourDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> EnseignantExisteDejaParNumeroExterne(Guid NumeroExterne)
        {
            var listEnseignant = _context.Enseignants.ToList();
            var Countenseignant = listEnseignant.Select(x => x.NumeroExterne.CompareTo(NumeroExterne) == 0).Count();
            if (Countenseignant != 0)
                    return true;

            return false;
        }

        public async Task<Enseignant?> LireEnseignantParNumeroExterne(Guid numeroExterne)
        {
            var listEnseignant = _context.Enseignants.ToList();
            var enseignant = listEnseignant.Where(x => x.NumeroExterne.CompareTo(numeroExterne) == 0)
                .SingleOrDefault();
            return enseignant;
        }
    }
}
