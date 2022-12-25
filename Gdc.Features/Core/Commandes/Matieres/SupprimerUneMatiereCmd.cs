using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.Matieres
{
    public class SupprimerUneMatiereCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid MatiereId { get; set; }
    }
}
