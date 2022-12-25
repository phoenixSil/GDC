using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Enseignants;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;

namespace Gdc.Features.Core.Handlers.Enseignants
{
    public class LireToutesLesEnseignantsCmdHdler : BaseCommandHandler<LireTousLesEnseignantsCmd, List<EnseignantDto>>
    {
        private readonly ILogger<LireToutesLesEnseignantsCmdHdler> _logger;

        public LireToutesLesEnseignantsCmdHdler(ILogger<LireToutesLesEnseignantsCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<List<EnseignantDto>> Handle(LireTousLesEnseignantsCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDenseignant.Lire();
            var list = _mapper.Map<List<EnseignantDto>>(result);

            return _mapper.Map<List<EnseignantDto>>(list);
        }
    }
}
