using AutoMapper;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class LireToutesLesEnseignantsCmdHdler : IRequestHandler<LireTousLesEnseignantsCmd, List<EnseignantDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireToutesLesEnseignantsCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<EnseignantDto>> Handle(LireTousLesEnseignantsCmd request, CancellationToken cancellationToken)
        {
            var result = await _pointDaccess.RepertoireDenseignant.Lire();
            var list = _mapper.Map<List<EnseignantDto>>(result);

            return _mapper.Map<List<EnseignantDto>>(list);
        }
    }
}
