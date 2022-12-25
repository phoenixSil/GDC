using Gdc.Features.Dtos.Enseignants;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Commandes.Enseignants
{
    public class LireUnEnseignantCmd : BaseCommand<EnseignantDetailDto>
    {
        public Guid EnseignantId { get; set; }
    }

    public class LireEnseignantParNumeroExterneCmd : BaseCommand<EnseignantDto>
    {
        public Guid NumeroExterne { get; set; }
    }
}
