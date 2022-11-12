using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Datas;
using MsCommun.Repertoires;
using MsCommun.Repertoires.Contrats;

namespace Gdc.Api.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        public RepertoireDeNiveau(CourDbContext context) : base(context)
        { }
    }
}
