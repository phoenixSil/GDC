using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Contrats.Services;
using Gdc.Features.Dtos.Matieres;
using MediatR;
using MsCommun.Reponses;
using Gdc.Features.Core.Commandes.Matieres;

namespace Gdc.Application.Services
{
    public class ServiceDeMatiere: IServiceDeMatiere
    {
        private readonly IMediator _mediator;
        public ServiceDeMatiere(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUneMatiere(MatiereACreerDto matiereDto)
        {
            var response = await _mediator.Send(new AjouterMatiereCmd { MatiereAAjouterDto = matiereDto });
            return response;
        }
          
        public async Task<MatiereDetailDto> LireUneMatiere(Guid matiereId)
        {
            var response = await _mediator.Send(new LireUneMatiereCmd { MatiereId = matiereId });
            return response;
        }

        public async Task<List<MatiereDto>> LireToutesLesMatieres()
        {
            var response = await _mediator.Send(new LireToutesLesMatieresCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierUneMatiere(Guid matiereId, MatiereAModifierDto matiereDto)
        {
            var response = await _mediator.Send(new ModifierUneMatiereCmd { MatiereId = matiereId, MatiereAModifierDto = matiereDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerUneMatiere(Guid matiereId)
        {
            var response = await _mediator.Send(new SupprimerUneMatiereCmd { MatiereId = matiereId });
            return response;
        }
    }
}
