using AutoMapper;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class LireUnCoursGeneriqueCmdHdler : IRequestHandler<LireUnCoursGeneriqueCmd, CoursGeneriqueDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireUnCoursGeneriqueCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }


        public async Task<CoursGeneriqueDetailDto> Handle(LireUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            if (request.CoursGeneriqueId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.CoursGeneriqueId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);
            var coursGenerique = _mapper.Map<CoursGeneriqueDetailDto>(result);

            return coursGenerique;
        }
    }
}
