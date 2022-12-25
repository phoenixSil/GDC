using AutoMapper;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Core.Commandes.CoursGeneriques;
using Gdc.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;

namespace Gdc.Features.Core.Handlers.CoursGeneriques
{
    public class LireToutesLesCoursGeneriquesCmdHdler : BaseCommandHandler<LireTousLesCoursGeneriquesCmd, List<CoursGeneriqueDto>>
    {
        private readonly ILogger<AjouterCoursGeneriqueCmdHdler> _logger;

        public LireToutesLesCoursGeneriquesCmdHdler(ILogger<AjouterCoursGeneriqueCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<List<CoursGeneriqueDto>> Handle(LireTousLesCoursGeneriquesCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeCoursGenerique.Lire();
            var list = _mapper.Map<List<CoursGeneriqueDto>>(result);

            return _mapper.Map<List<CoursGeneriqueDto>>(list);
        }
    }
}
