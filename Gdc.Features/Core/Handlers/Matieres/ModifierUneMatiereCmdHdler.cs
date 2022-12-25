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

namespace Gdc.Features.Core.Handlers.Matieres
{
    public class ModifierUneMatiereCmdHdler : BaseCommandHandler<ModifierUneMatiereCmd, ReponseDeRequette>
    {
        private readonly ILogger<ModifierUneMatiereCmdHdler> _logger;

        public ModifierUneMatiereCmdHdler(ILogger<ModifierUneMatiereCmdHdler> logger , IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }
        public override async Task<ReponseDeRequette> Handle(ModifierUneMatiereCmd request, CancellationToken cancellationToken)
        {
            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere is null)
                throw new NotFoundException(nameof(matiere), request.MatiereId);

            if (request.MatiereAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDuneMatiereDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.MatiereAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeMatiere.Exists(request.MatiereId))
                    throw new BadRequestException($"L'un des Ids Matiere::[{request.MatiereId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.MatiereAModifierDto, matiere);

                await _pointDaccess.RepertoireDeMatiere.Modifier(matiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = matiere.Id;

                return reponse;
            }
            throw new BadRequestException("matiere a Modifier est null");
        }
    }
}
