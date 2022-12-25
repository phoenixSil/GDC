using AutoMapper;
using Gdc.Features.Dtos.Programmations.Validateurs;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Dtos.CoursGeneriques.Validateurs;
using Gdc.Features.Core.Commandes.CoursGeneriques;
using Microsoft.Extensions.Logging;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Core.Handlers.CoursGeneriques
{
    public class AjouterCoursGeneriqueCmdHdler : BaseCommandHandler<AjouterCoursGeneriqueCmd, ReponseDeRequette>
    {
        private readonly ILogger<AjouterCoursGeneriqueCmdHdler> _logger;

        public AjouterCoursGeneriqueCmdHdler(ILogger<AjouterCoursGeneriqueCmdHdler> logger, IMediator mediator, IPointDaccess pointDaccess, IMapper mapper)
            : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<ReponseDeRequette> Handle(AjouterCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle personne dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeCoursGeneriqueDto();
            var resultatValidation = await validateur.ValidateAsync(request.CoursGeneriqueAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogWarning(" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas ");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune CoursGenerique a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var personneACreer = _mapper.Map<CoursGenerique>(request.CoursGeneriqueAAjouterDto);
                var result = await _pointDaccess.RepertoireDeCoursGenerique.Ajoutter(personneACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    _logger.LogError(" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti ");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune CoursGenerique a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    _logger.LogInformation(" Handle: LAjout de personne a reussit !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de CoursGenerique Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
