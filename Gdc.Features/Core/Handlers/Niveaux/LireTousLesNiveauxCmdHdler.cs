using AutoMapper;
using MediatR;
using Gdc.Domain.Modeles;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Core.Commandes.Niveaux;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Handlers.Niveaux
{
    public class LireTousLesNiveauxCmdHdler : BaseCommandHandler<LireTousLesNiveauxCmd, List<NiveauDto>>
    {

        private readonly ILogger<LireTousLesNiveauxCmdHdler> _logger;

        public LireTousLesNiveauxCmdHdler(ILogger<LireTousLesNiveauxCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<List<NiveauDto>> Handle(LireTousLesNiveauxCmd request, CancellationToken cancellationToken)
        {

            var listNiveau = await _pointDaccess.RepertoireDeNiveau.Lire();

            var listNiveauDto = _mapper.Map<List<NiveauDto>>(listNiveau);

            return listNiveauDto;
        }
    }
}
