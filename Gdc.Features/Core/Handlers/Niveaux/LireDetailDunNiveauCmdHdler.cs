using AutoMapper;
using MediatR;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Core.Commandes.Niveaux;
using MsCommun.Exceptions;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.Handlers.Matieres;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Handlers.Niveaux
{
    public class LireDetailDUnNiveauCmdHdler : BaseCommandHandler<LireDetailDUnNiveauCmd, NiveauDetailDto>
    {

        private readonly ILogger<LireDetailDUnNiveauCmdHdler> _logger;

        public LireDetailDUnNiveauCmdHdler(ILogger<LireDetailDUnNiveauCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override  async Task<NiveauDetailDto> Handle(LireDetailDUnNiveauCmd request, CancellationToken cancellationToken)
        {
            _logger.LogError($"Lecture du detail dun Niveau ");
            if (request.Id.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id.Value);
                var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);
                return NiveauDetail;
            }
            else if (request.NumeroExterne.HasValue)
            {
                var niveau = await _pointDaccess.RepertoireDeNiveau.LireParNumeroExterne(request.NumeroExterne.Value);
                var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);
                return NiveauDetail;
            }
            else
            {
                _logger.LogError($"Une erreur Inconnue est survenue {request.Id} et NumeroExterne {request.NumeroExterne}");
                throw new BadRequestException($"Une erreur Inconnue est survenue {request.Id} et NumeroExterne {request.NumeroExterne}");
            }
        }
    }
}
