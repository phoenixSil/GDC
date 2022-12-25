using AutoMapper;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Core.Commandes.CoursGeneriques;
using Gdc.Features.Core.BaseFactoryClass;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Gdc.Features.Core.Handlers.CoursGeneriques
{
    public class LireUnCoursGeneriqueCmdHdler : BaseCommandHandler<LireUnCoursGeneriqueCmd, CoursGeneriqueDetailDto>
    {
        private readonly ILogger<LireUnCoursGeneriqueCmdHdler> _logger;

        public LireUnCoursGeneriqueCmdHdler(ILogger<LireUnCoursGeneriqueCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper, IMediator mediator)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<CoursGeneriqueDetailDto> Handle(LireUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            if (request.CoursGeneriqueId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.CoursGeneriqueId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);
            var coursGenerique = _mapper.Map<CoursGeneriqueDetailDto>(result);

            return coursGenerique;
        }
    }
}
