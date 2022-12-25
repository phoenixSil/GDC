using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;


namespace Gdc.Features.Core.Commandes.CoursGeneriques
{
    public class SupprimerUnCoursGeneriqueCmd : BaseCommand<ReponseDeRequette>
    {
        public Guid CoursGeneriqueId { get; set; }
    }
}          
