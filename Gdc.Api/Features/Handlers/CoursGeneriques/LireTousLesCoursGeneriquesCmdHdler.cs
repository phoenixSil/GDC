using AutoMapper;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class LireToutesLesCoursGeneriquesCmdHdler : IRequestHandler<LireTousLesCoursGeneriquesCmd, List<CoursGeneriqueDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireToutesLesCoursGeneriquesCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<CoursGeneriqueDto>> Handle(LireTousLesCoursGeneriquesCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeCoursGenerique.Lire();
            var list = _mapper.Map<List<CoursGeneriqueDto>>(result);

            return _mapper.Map<List<CoursGeneriqueDto>>(list);
        }
    }
}
