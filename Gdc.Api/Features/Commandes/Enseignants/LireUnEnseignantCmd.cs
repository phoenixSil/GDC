using Gdc.Api.Dtos.Enseignants;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class LireUnEnseignantCmd : IRequest<EnseignantDetailDto>
    {
        public Guid EnseignantId { get; internal set; }
    }

    public class LireEnseignantParNumeroExterneCmd: IRequest<EnseignantDto>
    {
        public Guid NumeroExterne { get; internal set; }
    }
}
