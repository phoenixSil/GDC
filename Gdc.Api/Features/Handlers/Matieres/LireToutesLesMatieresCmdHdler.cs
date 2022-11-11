using AutoMapper;
using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class LireToutesLesMatieresCmdHdler : IRequestHandler<LireToutesLesMatieresCmd, List<MatiereDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireToutesLesMatieresCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }


        public async Task<List<MatiereDto>> Handle(LireToutesLesMatieresCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDeMatiere.Lire();
            var list = _mapper.Map<List<MatiereDto>>(result);

            return _mapper.Map<List<MatiereDto>>(list);
        }
    }
}
