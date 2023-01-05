using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.Programmations.Validateurs;
using Gdc.Api.DTOs.Programmations.Validateurs;
using Gdc.Features.Core.Commandes.Enseignants;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;
using Newtonsoft.Json;
using System.Net;

namespace Gdc.Features.Core.Handlers.Enseignants
{
    public class ModifierUnEnseignantCmdHdler : BaseCommandHandler<ModifierUnEnseignantCmd, ReponseDeRequette>
    {

        private readonly ILogger<ModifierUnEnseignantCmdHdler> _logger;


        public ModifierUnEnseignantCmdHdler(ILogger<ModifierUnEnseignantCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUnEnseignantCmd request, CancellationToken cancellationToken)
        {
             _logger.LogInformation($"On vas essayer de Modifier une Enseignant . Donness {JsonConvert.SerializeObject(request.EnseignantAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant is null)
            {
                reponse.Success = false;
                reponse.Message = "L'enseignant specifier est introuvable ";
                reponse.Id = request.EnseignantId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"l'enseignant nexsite pas Id : [{request.EnseignantId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDunEnseignantDto();
                var resultatValidation = await validateur.ValidateAsync(request.EnseignantAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees de l' enseignant ne sont pas valides  ";
                    reponse.Id = request.EnseignantId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees de l'enseignant ne sont pas valides : {JsonConvert.SerializeObject(request.EnseignantAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.EnseignantAModifierDto, enseignant);

                    await _pointDaccess.RepertoireDenseignant.Modifier(enseignant);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = enseignant.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification du Enseignant Reussit ID: [{request.EnseignantId}]");
                }
            }
            return reponse;
        }
    }
}
