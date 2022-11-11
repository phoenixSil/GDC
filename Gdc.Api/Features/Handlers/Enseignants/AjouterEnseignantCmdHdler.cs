﻿using AutoMapper;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Dtos.Programmations.Validateurs;
using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class AjouterEnseignantCmdHdler : IRequestHandler<AjouterEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly ILogger<AjouterEnseignantCmdHdler> _logger;
        public AjouterEnseignantCmdHdler(ILogger<AjouterEnseignantCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ReponseDeRequette> Handle(AjouterEnseignantCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvelle personne dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDunEnseignantDto();
            var resultatValidation = await validateur.ValidateAsync(request.EnseignantAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogWarning(" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas ");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Enseignant a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                if(( await _pointDaccess.RepertoireDenseignant.EnseignantExisteDejaParNumeroExterne(request.EnseignantAAjouterDto.NumeroExterne)) == true)
                {
                    _logger.LogInformation(" Handle: Enseignant Exite deja !!! ");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Enseignant Reussit";
                } else
                {
                    var personneACreer = _mapper.Map<Enseignant>(request.EnseignantAAjouterDto);
                    var result = await _pointDaccess.RepertoireDenseignant.Ajoutter(personneACreer);
                    await _pointDaccess.Enregistrer();

                    if (result == null)
                    {
                        _logger.LogError(" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti ");
                        reponse.Success = false;
                        reponse.Message = "Echec de Lajout dune Enseignant a la personne donc l'Id est notee dans le champs d'Id";
                    }
                    else
                    {
                        _logger.LogInformation(" Handle: LAjout de personne a reussit !!! ");
                        reponse.Success = true;
                        reponse.Message = "Ajout de Enseignant Reussit";
                        reponse.Id = result.Id;
                    }
                }
            }
            return reponse;
        }
    }
}
