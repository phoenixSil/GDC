using Gdc.Api.Dtos.Niveaux;
using MediatR;

namespace Gdc.Api.Features.Commandes.Niveaux
{
    public class LireDetailDUnNiveauCmd : IRequest<NiveauDetailDto>
    {
        public Guid Id { get; set; }
    }
}
