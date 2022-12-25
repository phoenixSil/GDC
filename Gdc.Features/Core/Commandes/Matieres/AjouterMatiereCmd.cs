using Gdc.Features.Dtos.Matieres;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.Matieres
{
    public class AjouterMatiereCmd : BaseCommand<ReponseDeRequette>
    {
        public MatiereACreerDto MatiereAAjouterDto { get;  set; }
    }
}
