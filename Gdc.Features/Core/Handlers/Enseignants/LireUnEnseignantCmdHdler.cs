using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Enseignants;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;

namespace Gdc.Features.Core.Handlers.Enseignants
{
    public class LireUnEnseignantCmdHdler : BaseCommandHandler<LireUnEnseignantCmd, EnseignantDetailDto>
    {
        private readonly ILogger<LireUnEnseignantCmdHdler> _logger;

        public LireUnEnseignantCmdHdler(ILogger<LireUnEnseignantCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<EnseignantDetailDto> Handle(LireUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            if (request.EnseignantId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.EnseignantId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);
            var enseignant = _mapper.Map<EnseignantDetailDto>(result);

            return enseignant;
        }
    }

    public class LireEnseignantParNumeroExterneCmdHdler : BaseCommandHandler<LireEnseignantParNumeroExterneCmd, EnseignantDto>
    {

        private readonly ILogger<LireEnseignantParNumeroExterneCmdHdler> _logger;

        public LireEnseignantParNumeroExterneCmdHdler(ILogger<LireEnseignantParNumeroExterneCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<EnseignantDto> Handle(LireEnseignantParNumeroExterneCmd request, CancellationToken cancellationToken)
        {
            if (request.NumeroExterne.Equals(Guid.Empty))
                throw new BadRequestException($"le NumeroExterne [{request.NumeroExterne}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDenseignant.LireEnseignantParNumeroExterne(request.NumeroExterne);
            var enseignant = _mapper.Map<EnseignantDto>(result);

            return enseignant;
        }
    }
}
