using Gdc.Api.Dtos.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gdc.Api.Features.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public NiveauGdcACreerDto  NiveauAAjouterDto { get; set; }
    }
}
