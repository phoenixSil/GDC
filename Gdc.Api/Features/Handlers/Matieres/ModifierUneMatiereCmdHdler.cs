using AutoMapper;
using Gdc.Api.Dtos.Matieres;
using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.Matieres.Validateurs;
using Gdc.Api.DTOs.Matieres.Validateurs;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class ModifierUneMatiereCmdHdler : IRequestHandler<ModifierUneMatiereCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public ModifierUneMatiereCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUneMatiereCmd request, CancellationToken cancellationToken)
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
