using AutoMapper;
using Gdc.Api.Dtos.Enseignants;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class LireUnEnseignantCmdHdler : IRequestHandler<LireUnEnseignantCmd, EnseignantDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireUnEnseignantCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }


        public async Task<EnseignantDetailDto> Handle(LireUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            if (request.EnseignantId.Equals(Guid.Empty))
                throw new BadRequestException($"Id [{request.EnseignantId}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);
            var enseignant = _mapper.Map<EnseignantDetailDto>(result);

            return enseignant;
        }
    }

    public class LireEnseignantParNumeroExterneCmdHdler : IRequestHandler<LireEnseignantParNumeroExterneCmd, EnseignantDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        public LireEnseignantParNumeroExterneCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }


        public async Task<EnseignantDto> Handle(LireEnseignantParNumeroExterneCmd request, CancellationToken cancellationToken)
        {
            if (request.NumeroExterne.Equals(Guid.Empty))
                throw new BadRequestException($"le NumeroExterne [{request.NumeroExterne}] que vous avez entrez est null");

            var result = await _pointDaccess.RepertoireDenseignant.LireEnseignantParNumeroExterne(request.NumeroExterne);
            var enseignant = _mapper.Map<EnseignantDto>(result);

            return enseignant;
        }
    }
}
