using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Dtos.Niveaux;
using MediatR;

namespace Gdc.Features.Core.Commandes.Niveaux
{
    public class LireDetailDUnNiveauCmd : BaseCommand<NiveauDetailDto>
    {
        public Guid? Id { get; set; }
        public Guid? NumeroExterne { get; set; }
    }
}
