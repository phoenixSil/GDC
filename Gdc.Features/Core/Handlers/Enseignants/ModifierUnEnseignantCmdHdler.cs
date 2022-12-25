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
            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if (enseignant is null)
                throw new NotFoundException(nameof(enseignant), request.EnseignantId);

            if (request.EnseignantAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDunEnseignantDto();
                var resultatValidation = await validateur.ValidateAsync(request.EnseignantAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDenseignant.Exists(request.EnseignantId))
                    throw new BadRequestException($"L'un des Ids Enseignant::[{request.EnseignantId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.EnseignantAModifierDto, enseignant);

                await _pointDaccess.RepertoireDenseignant.Modifier(enseignant);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = enseignant.Id;

                return reponse;
            }
            throw new BadRequestException("enseignant a Modifier est null");
        }
    }
}
