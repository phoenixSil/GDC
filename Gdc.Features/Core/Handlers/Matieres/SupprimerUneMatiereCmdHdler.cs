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
using System.Net;
using MassTransit;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class SupprimerUneMatiereCmdHdler : BaseCommandHandler<SupprimerUneMatiereCmd, ReponseDeRequette>
    {
        private readonly ILogger<SupprimerUneMatiereCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public SupprimerUneMatiereCmdHdler(IPublishEndpoint publishEndPoint, ILogger<SupprimerUneMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }
        public override async Task<ReponseDeRequette> Handle(SupprimerUneMatiereCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.MatiereId == Guid.Empty)
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere is not null)
            {
                await _pointDaccess.RepertoireDeMatiere.Supprimer(matiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.MatiereId;
                reponse.StatusCode = (int)HttpStatusCode.OK;

                // deposer la matiere creer sur le Bus 
                var dtoMatiere = GenerateDtoMatierePourLeBus(request.MatiereId);
                await _publishEndPoint.Publish(dtoMatiere, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                throw new NotFoundException(nameof(Matiere), request.MatiereId);
            }
            return reponse;
        }

        private MatiereASupprimerMessage GenerateDtoMatierePourLeBus(Guid matiereId)
        {
            return new MatiereASupprimerMessage
            {
                Id = matiereId,
                Service = DesignationService.SERVICE_GDC,
                Type = TypeMessage.SUPPRESSION
            };
        }
    }
}
