using AutoMapper;
using Gdc.Api.Dtos.Matieres.Validateurs;
using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class AjouterMatiereCmdHdler : IRequestHandler<AjouterMatiereCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterMatiereCmdHdler> _logger;
        public AjouterMatiereCmdHdler(ILogger<AjouterMatiereCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ReponseDeRequette> Handle(AjouterMatiereCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle personne dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDuneMatiereDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.MatiereAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogWarning(" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas ");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Matiere a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var personneACreer = _mapper.Map<Matiere>(request.MatiereAAjouterDto);
                var result = await _pointDaccess.RepertoireDeMatiere.Ajoutter(personneACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    _logger.LogError(" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti ");
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Matiere a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    _logger.LogInformation(" Handle: LAjout de personne a reussit !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Matiere Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
