using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Commandes.CoursGeneriques;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using MassTransit;
using System.Net;
using Gdc.Features.Core.BaseFactoryClass;
using AutoMapper;

namespace Gdc.Features.Core.Handlers.CoursGeneriques
{
    public class SupprimerUnCoursGeneriqueCmdHdler : BaseCommandHandler<SupprimerUnCoursGeneriqueCmd, ReponseDeRequette>
    {
       
        private readonly ILogger<SupprimerUnCoursGeneriqueCmdHdler> _logger;

        public SupprimerUnCoursGeneriqueCmdHdler(IPointDaccess pointDaccess, ILogger<SupprimerUnCoursGeneriqueCmdHdler> logger, IMapper mapper, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<ReponseDeRequette> Handle(SupprimerUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"On vas essayer de supprimer le Cours generique d'Id [{request.CoursGeneriqueId}]");
                
                var reponse = new ReponseDeRequette();

                if (request.CoursGeneriqueId == Guid.Empty)
                    throw new BadRequestException($"Id [{request.CoursGeneriqueId}] que vous avez entrez est null");

                var coursGenerique = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);

                if (coursGenerique is not null)
                {
                    var resultat = await _pointDaccess.RepertoireDeCoursGenerique.Supprimer(coursGenerique);
                    
                    if(resultat is true)
                    {
                        reponse.Success = true;
                        reponse.Message = "Suppression Reussit ";
                        reponse.StatusCode = (int)HttpStatusCode.OK;
                    } else
                    {
                        reponse.Success = false;
                        reponse.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                        reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                }
                else
                {
                    _logger.LogInformation($"le cours d'Id [{request.CoursGeneriqueId}] nexiste pas dans la base de donnees ");
                    reponse.Success = false;
                    reponse.Message = "Un Probleme est survenue lors de la suppression du Cours generique";
                    reponse.StatusCode = (int)HttpStatusCode.NotFound;
                }
                return reponse;
            }
            catch (Exception e)
            {
                throw new ApplicationException("apparition dune erreur non connu", e);
            }
            
        }
    }
}
