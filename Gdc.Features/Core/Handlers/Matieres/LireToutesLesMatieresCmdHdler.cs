using AutoMapper;
using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Matieres;
using Gdc.Features.Core.Handlers.Enseignants;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class LireToutesLesMatieresCmdHdler : BaseCommandHandler<LireToutesLesMatieresCmd, List<MatiereDto>>
    {

        private readonly ILogger<LireToutesLesMatieresCmdHdler> _logger;

        public LireToutesLesMatieresCmdHdler(ILogger<LireToutesLesMatieresCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }


        public override async Task<List<MatiereDto>> Handle(LireToutesLesMatieresCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeMatiere.Lire();
            var list = _mapper.Map<List<MatiereDto>>(result);

            return _mapper.Map<List<MatiereDto>>(list);
        }
    }
}
