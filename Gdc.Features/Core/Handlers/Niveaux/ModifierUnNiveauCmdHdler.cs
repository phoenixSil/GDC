using AutoMapper;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Dtos.Niveaux.Validations;
using Gdc.Features.Core.Commandes.Niveaux;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Gdc.Features.Core.Handlers.Niveaux
{
    public class ModifierUnNiveauCmdHdler : BaseCommandHandler<ModifierUnNiveauCmd, ReponseDeRequette>
    {

        private readonly ILogger<ModifierUnNiveauCmdHdler> _logger;


        public ModifierUnNiveauCmdHdler(ILogger<ModifierUnNiveauCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUnNiveauCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier un Niveau . Donness {JsonConvert.SerializeObject(request.NiveauAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.NiveauId);

            if (niveau is null)
            {
                reponse.Success = false;
                reponse.Message = "Le niveau specifier est introuvable ";
                reponse.Id = request.NiveauId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"le niveau nexsite pas Id : [{request.NiveauId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDeNiveauDto();
                var resultatValidation = await validateur.ValidateAsync(request.NiveauAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees du niveau ne sont pas valides  ";
                    reponse.Id = request.NiveauId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees du niveau ne sont pas valides : {JsonConvert.SerializeObject(request.NiveauAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.NiveauAModifierDto, niveau);

                    await _pointDaccess.RepertoireDeNiveau.Modifier(niveau);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = niveau.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification du Niveau Reussit ID: [{request.NiveauId}]");
                }
            }
            return reponse;
        }
    }
}
