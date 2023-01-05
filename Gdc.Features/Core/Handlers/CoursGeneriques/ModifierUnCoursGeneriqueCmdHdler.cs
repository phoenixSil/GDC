using AutoMapper;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.Programmations.Validateurs;
using Gdc.Api.DTOs.Programmations.Validateurs;
using Gdc.Features.Dtos.CoursGeneriques.Validateurs;
using Gdc.Features.Core.Commandes.CoursGeneriques;
using Gdc.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Gdc.Features.Core.Handlers.CoursGeneriques
{
    public class ModifierUnCoursGeneriqueCmdHdler : BaseCommandHandler<ModifierUnCoursGeneriqueCmd, ReponseDeRequette>
    {

        private readonly ILogger<ModifierUnCoursGeneriqueCmdHdler> _logger;

        public ModifierUnCoursGeneriqueCmdHdler(ILogger<ModifierUnCoursGeneriqueCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier un CoursGenerique . Donness {JsonConvert.SerializeObject(request.CoursGeneriqueAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var coursGenerique = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);

            if (coursGenerique is null)
            {
                reponse.Success = false;
                reponse.Message = "Le coursGenerique specifier est introuvable ";
                reponse.Id = request.CoursGeneriqueId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"le coursGenerique nexsite pas Id : [{request.CoursGeneriqueId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDeCoursGeneriqueDto();
                var resultatValidation = await validateur.ValidateAsync(request.CoursGeneriqueAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees du coursGenerique ne sont pas valides  ";
                    reponse.Id = request.CoursGeneriqueId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees du coursGenerique ne sont pas valides : {JsonConvert.SerializeObject(request.CoursGeneriqueAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.CoursGeneriqueAModifierDto, coursGenerique);

                    await _pointDaccess.RepertoireDeCoursGenerique.Modifier(coursGenerique);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = coursGenerique.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification du CoursGenerique Reussit ID: [{request.CoursGeneriqueId}]");
                }
            }
            return reponse;
        }
    }
}
