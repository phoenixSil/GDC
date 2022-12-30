using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Data;
using MsCommun.Repertoires;
using Gdc.Features.Dtos.Matieres;
using Microsoft.EntityFrameworkCore;

namespace Gdc.Data.Repertoires
{
    public class RepertoireDeMatiere : RepertoireGenerique<Matiere>, IRepertoireDeMatiere
    {
        private readonly CourDbContext _context;

        public RepertoireDeMatiere(CourDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Matiere> LireDetail(Guid id)
        {
            var matiere = await _context.Matieres
                            .Include(mat => mat.Niveau)
                            .Include(mat => mat.CoursGenerique)
                            .Include(mat => mat.Enseignant)
                            .SingleOrDefaultAsync(mat => mat.Id == id).ConfigureAwait(false);

            return matiere;
        }
    }
}
