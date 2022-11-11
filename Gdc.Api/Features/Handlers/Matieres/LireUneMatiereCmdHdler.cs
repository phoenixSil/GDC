using AutoMapper;
using Gdc.Api.Dtos.Matieres;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class LireUneMatiereCmdHdler : IRequestHandler<LireUneMatiereCmd, MatiereDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireUneMatiereCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }


        public async Task<MatiereDetailDto> Handle(LireUneMatiereCmd request, CancellationToken cancellationToken)
        {
            if (request.MatiereId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);
            var matiere = _mapper.Map<MatiereDetailDto>(result);

            return matiere;
        }
    }
}
