using Gdc.Api.Repertoires;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Datas;

namespace Gdc.Api.Repertoires
{
    public class PointDaccess : IPointDaccess
    {
        private readonly CourDbContext _context;
        private IRepertoireDeMatiere _repertoireDeMatiere;
        private IRepertoireDenseignant _repertoireDenseignant;
        private IRepertoireDeCoursGenerique _repertoireDeCoursGenerique;
        private IRepertoireDeNiveau _repertoireDeNiveau;

        public PointDaccess(CourDbContext context)
        {
            _context = context;
        }

        public async Task Enregistrer()
        {
            await _context.SaveChangesAsync();
        }

        public IRepertoireDeMatiere RepertoireDeMatiere => _repertoireDeMatiere ??= new RepertoireDeMatiere(_context);
        public IRepertoireDenseignant RepertoireDenseignant => _repertoireDenseignant ??= new RepertoireDenseignant(_context);
        public IRepertoireDeCoursGenerique RepertoireDeCoursGenerique => _repertoireDeCoursGenerique ??= new RepertoireDeCoursGenerique(_context);
        public IRepertoireDeNiveau RepertoireDeNiveau => _repertoireDeNiveau ??= new RepertoireDeNiveau(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
