using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Commandes.Enseignants;
using AutoMapper;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using System.Net;
using MassTransit;

namespace Gdc.Features.Core.Handlers.Enseignants
{
    public class SupprimerUnEnseignantCmdHdler : BaseCommandHandler<SupprimerUnEnseignantCmd, ReponseDeRequette>
    {

        private readonly ILogger<SupprimerUnEnseignantCmdHdler> _logger;

        public SupprimerUnEnseignantCmdHdler(ILogger<SupprimerUnEnseignantCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(SupprimerUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant is null)
            {
                reponse.Success = false;
                reponse.Message = $"l'enseignant d\"Id [{request.EnseignantId}] n'existe pas dans la base :: coursDb";
                reponse.Id = request.EnseignantId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                var resultat = await _pointDaccess.RepertoireDenseignant.Supprimer(enseignant);

                if(resultat is false)
                {
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;

                    reponse.Success = false;
                    reponse.Message = "Suppression Non effectuer de lenseignant ";
                    reponse.Id = request.EnseignantId;
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    reponse.Success = true;
                    reponse.Message = "Suppression Reussit ";
                    reponse.Id = request.EnseignantId;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                }
            }

            return reponse;
        }
    }
}
