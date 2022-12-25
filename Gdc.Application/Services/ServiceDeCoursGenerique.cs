using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Contrats.Services;
using MediatR;
using MsCommun.Reponses;
using Gdc.Features.Core.Commandes.CoursGeneriques;

namespace Gdc.Application.Services
{
    public class ServiceDeCoursGenerique: IServiceDeCoursGenerique
    {
        private readonly IMediator _mediator;

        public ServiceDeCoursGenerique(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<ReponseDeRequette> AjouterUnCoursGenerique(CoursGeneriqueACreerDto suivitMatiereDto)
        {
            var response = await _mediator.Send(new AjouterCoursGeneriqueCmd { CoursGeneriqueAAjouterDto = suivitMatiereDto });
            return response;
        }

        public async Task<CoursGeneriqueDetailDto> LireUnCoursGenerique(Guid suivitMatiereId)
        {
            var response = await _mediator.Send(new LireUnCoursGeneriqueCmd { CoursGeneriqueId = suivitMatiereId });
            return response;
        }

        public async Task<List<CoursGeneriqueDto>> LireTousLesCoursGeneriques()
        {
            var response = await _mediator.Send(new LireTousLesCoursGeneriquesCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierUnCoursGenerique(Guid suivitMatiereId, CoursGeneriqueAModifierDto suivitMatiereDto)
        {
            var response = await _mediator.Send(new ModifierUnCoursGeneriqueCmd { CoursGeneriqueId = suivitMatiereId, CoursGeneriqueAModifierDto = suivitMatiereDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerUnCoursGenerique(Guid suivitMatiereId)
        {
            var response = await _mediator.Send(new SupprimerUnCoursGeneriqueCmd { CoursGeneriqueId = suivitMatiereId });
            return response;
        }

    }
}
