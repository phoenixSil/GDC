using Gdc.Api.Dtos.Matieres;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class LireToutesLesMatieresCmd : IRequest<List<MatiereDto>>
    {
    }
}
