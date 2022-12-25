using Gdc.Features.Dtos.Niveaux;
using MediatR;
using MsCommun.Reponses;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : BaseCommand<ReponseDeRequette>
    {
        public NiveauACreerDto NiveauAAjouterDto { get; set; }
    }
}
