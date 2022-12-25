using AutoMapper;
using Gdc.Features.Dtos.Matieres;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Matieres;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class LireUneMatiereCmdHdler : BaseCommandHandler<LireUneMatiereCmd, MatiereDetailDto>
    {
        private readonly ILogger<LireUneMatiereCmdHdler> _logger;

        public LireUneMatiereCmdHdler(ILogger<LireUneMatiereCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<MatiereDetailDto> Handle(LireUneMatiereCmd request, CancellationToken cancellationToken)
        {
            if (request.MatiereId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);
            var matiere = _mapper.Map<MatiereDetailDto>(result);

            return matiere;
        }
    }
}
