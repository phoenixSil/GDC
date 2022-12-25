using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Commandes.Matieres;
using AutoMapper;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class SupprimerUneMatiereCmdHdler : BaseCommandHandler<SupprimerUneMatiereCmd, ReponseDeRequette>
    {

        private readonly ILogger<SupprimerUneMatiereCmdHdler> _logger;

        public SupprimerUneMatiereCmdHdler(ILogger<SupprimerUneMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(SupprimerUneMatiereCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.MatiereId == Guid.Empty)
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere != null)
            {
                await _pointDaccess.RepertoireDeMatiere.Supprimer(matiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.MatiereId;

                return reponse;
            }
            throw new NotFoundException(nameof(Matiere), request.MatiereId);
        }
    }
}
