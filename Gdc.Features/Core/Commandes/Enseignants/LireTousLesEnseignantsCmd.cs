using Gdc.Features.Dtos.Enseignants;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Commandes.Enseignants
{
    public class LireTousLesEnseignantsCmd : BaseCommand<List<EnseignantDto>>
    {
    }
}
