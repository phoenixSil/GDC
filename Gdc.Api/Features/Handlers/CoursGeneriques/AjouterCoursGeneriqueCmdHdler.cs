using AutoMapper;
using Gdc.Api.Dtos.Programmations.Validateurs;
using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Dtos.CoursGeneriques.Validateurs;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class AjouterCoursGeneriqueCmdHdler : IRequestHandler<AjouterCoursGeneriqueCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterCoursGeneriqueCmdHdler> _logger;
        public AjouterCoursGeneriqueCmdHdler(ILogger<AjouterCoursGeneriqueCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ReponseDeRequette> Handle(AjouterCoursGeneriqueCmd request, CancellationToken cancellationToken)
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
