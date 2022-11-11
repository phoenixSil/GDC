using AutoMapper;
using MediatR;
using Gdc.Api.Features.Commandes.Niveaux;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Api.Dtos.Niveaux;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Api.Dtos.Niveaux;

namespace Gdc.Api.Features.CommandHandlers.Niveaux
{
    public class LireDetailDUnNiveauCmdHdler : IRequestHandler<LireDetailDUnNiveauCmd, NiveauDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnNiveauCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<NiveauDetailDto> Handle(LireDetailDUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id);
            var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);

            return NiveauDetail;
        }
    }
}
