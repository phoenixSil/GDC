﻿using AutoMapper;
using Gdc.Api.Dtos.Enseignants;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.Programmations.Validateurs;
using Gdc.Api.DTOs.Programmations.Validateurs;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class ModifierUnEnseignantCmdHdler : IRequestHandler<ModifierUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifierUnEnseignantCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnEnseignantCmd request, CancellationToken cancellationToken)
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
