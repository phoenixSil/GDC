using AutoMapper;
using Gdc.Features.Dtos.Matieres;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.Matieres.Validateurs;
using Gdc.Api.DTOs.Matieres.Validateurs;
using Gdc.Features.Core.Commandes.Matieres;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using System.Net;
using Castle.Core.Logging;
using Newtonsoft.Json;
using MassTransit;
using MsCommun.Messages.Matieres;
using Gdc.Domain.Modeles;
using MsCommun.Messages.Utils;

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class ModifierUneMatiereCmdHdler : BaseCommandHandler<ModifierUneMatiereCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierUneMatiereCmdHdler> _logger;
        private readonly IPublishEndpoint _publishEndPoint;

        public ModifierUneMatiereCmdHdler(IPublishEndpoint publishEndPoint, ILogger<ModifierUneMatiereCmdHdler> logger , IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
            _publishEndPoint = publishEndPoint;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUneMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier une Matiere . Donness {JsonConvert.SerializeObject(request.MatiereAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere is null)
            {
                reponse.Success = false;
                reponse.Message = "La matiere specifier est introuvable ";
                reponse.Id = request.MatiereId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"la matiere nexsite pas Id : [{request.MatiereId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDuneMatiereDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.MatiereAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees de la matiere ne sont pas valides  ";
                    reponse.Id = request.MatiereId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees de la matiere ne sont pas valides : {JsonConvert.SerializeObject(request.MatiereAModifierDto)}");
                }
                else
                {
                    _mapper.Map(request.MatiereAModifierDto, matiere);

                    await _pointDaccess.RepertoireDeMatiere.Modifier(matiere);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = matiere.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification de la Matiere Reussit ID: [{request.MatiereId}]");

                    // deposer la matiere creer sur le Bus 
                    var dtoMatiere = await GenerateDtoMatierePourLeBus(request.MatiereAModifierDto).ConfigureAwait(false);
                    await _publishEndPoint.Publish(dtoMatiere, cancellationToken).ConfigureAwait(false);

                }
            }
            return reponse;
        }

        private async Task<MatiereAModifierMessage> GenerateDtoMatierePourLeBus(MatiereAModifierDto matiere)
        {
            var matiereDetail = await _pointDaccess.RepertoireDeMatiere.LireDetail(matiere.Id);
            var matiereMapper = _mapper.Map<MatiereAModifierMessage>(matiereDetail);
            matiereMapper.Service = DesignationService.SERVICE_GDC;
            matiereMapper.Type = TypeMessage.MODIFICATION;
            return matiereMapper;
        }
    }
}
