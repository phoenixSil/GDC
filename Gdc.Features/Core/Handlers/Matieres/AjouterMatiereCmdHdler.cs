using AutoMapper;
using Gdc.Features.Dtos.Matieres.Validateurs;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Matieres;
using Microsoft.Extensions.Logging;
using Gdc.Domain.Modeles;
using System.Net;
using Newtonsoft.Json;
using MassTransit;
using Gdc.Features.Dtos.Matieres;
using MsCommun.Messages.Matieres;
using MsCommun.Messages.Utils;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class AjouterMatiereCmdHdler : BaseCommandHandler<AjouterMatiereCmd, ReponseDeRequette>
    {
       
        private readonly ILogger<AjouterMatiereCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public AjouterMatiereCmdHdler(IPublishEndpoint publishEndPoint, ILogger<AjouterMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }
        public override async Task<ReponseDeRequette> Handle(AjouterMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle matiere dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDuneMatiereDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.MatiereAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid is false)
            {
                _logger.LogWarning($" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas {JsonConvert.SerializeObject(request.MatiereAAjouterDto)}");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Matiere a la matiere donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var matiereACreer = _mapper.Map<Matiere>(request.MatiereAAjouterDto);
                var result = await _pointDaccess.RepertoireDeMatiere.Ajoutter(matiereACreer);

                if (result is null)
                {
                    _logger.LogError($" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti {JsonConvert.SerializeObject(request.MatiereAAjouterDto)}");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Matiere na pas marche ";
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    _logger.LogInformation(" Handle: LAjout de matiere a reussit !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Matiere Reussit";
                    reponse.Id = result.Id;
                    reponse.StatusCode = (int)HttpStatusCode.Created;

                    // deposer la matiere creer sur le Bus 
                    var dtoMatiere = await GenerateDtoMatierePourLeBus(result).ConfigureAwait(false);
                    await _publishEndPoint.Publish(dtoMatiere, cancellationToken).ConfigureAwait(false);
                }
            }

            return reponse;
        }

        private async Task<MatiereACreerMessage> GenerateDtoMatierePourLeBus(Matiere matiere)
        {
            var matiereDetail = await _pointDaccess.RepertoireDeMatiere.LireDetail(matiere.Id);
            var matiereMapper = _mapper.Map<MatiereACreerMessage>(matiereDetail);
            matiereMapper.Service = DesignationService.SERVICE_GDC;
            matiereMapper.Type = TypeMessage.CREATION;
            return matiereMapper;
        }
    }
}
