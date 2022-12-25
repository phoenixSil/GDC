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
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.NiveauId);

            if (niveau is null)
                throw new NotFoundException(nameof(niveau), request.NiveauId);

            if (request.NiveauAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeNiveauDto();
                var resultatValidation = await validateur.ValidateAsync(request.NiveauAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeNiveau.Exists(request.NiveauId))
                    throw new BadRequestException($"L'un des Ids Niveau::[{request.NiveauId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.NiveauAModifierDto, niveau);

                await _pointDaccess.RepertoireDeNiveau.Modifier(niveau);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = niveau.Id;

                return reponse;
            }
            throw new BadRequestException("niveau a Modifier est null");
        }
    }
}
