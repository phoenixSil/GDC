using Gdc.Features.Core.BaseFactoryClass;
using MediatR;
using MsCommun.Reponses;

namespace Gdc.Features.Core.Commandes.Niveaux
{
    public class SupprimerUnNiveauCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
