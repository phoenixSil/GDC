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
            var coursGenerique = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);

            if (coursGenerique is null)
                throw new NotFoundException(nameof(coursGenerique), request.CoursGeneriqueId);

            if (request.CoursGeneriqueAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeCoursGeneriqueDto();
                var resultatValidation = await validateur.ValidateAsync(request.CoursGeneriqueAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeCoursGenerique.Exists(request.CoursGeneriqueId))
                    throw new BadRequestException($"L'un des Ids CoursGenerique::[{request.CoursGeneriqueId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.CoursGeneriqueAModifierDto, coursGenerique);

                await _pointDaccess.RepertoireDeCoursGenerique.Modifier(coursGenerique);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = coursGenerique.Id;

                return reponse;
            }
            throw new BadRequestException("coursGenerique a Modifier est null");
        }
    }
}
