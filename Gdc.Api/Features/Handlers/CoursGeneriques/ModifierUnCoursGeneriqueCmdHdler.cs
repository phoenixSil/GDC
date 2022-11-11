using AutoMapper;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.Programmations.Validateurs;
using Gdc.Api.DTOs.Programmations.Validateurs;
using Gdc.Api.Dtos.CoursGeneriques.Validateurs;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class ModifierUnCoursGeneriqueCmdHdler : IRequestHandler<ModifierUnCoursGeneriqueCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifierUnCoursGeneriqueCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
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
