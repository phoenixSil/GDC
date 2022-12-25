using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.Enseignants
{
    public class SupprimerUnEnseignantCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid EnseignantId { get; set; }
    }
}
