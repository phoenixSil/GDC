using Gdc.Api.Dtos.Enseignants;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class AjouterEnseignantCmd : IRequest<ReponseDeRequette>
    {
        public EnseignantACreerDto EnseignantAAjouterDto { get; internal set; }
    }
}
