using AutoMapper;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Dtos.Programmations.Validateurs;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MediatR;
using Gdc.Features.Core.Commandes.Enseignants;
using Microsoft.Extensions.Logging;
using Gdc.Domain.Modeles;
using System.Net;

namespace Gdc.Features.Core.Handlers.Enseignants
{
    public class AjouterEnseignantCmdHdler : BaseCommandHandler<AjouterEnseignantCmd, ReponseDeRequette>
    {
        private readonly ILogger<AjouterEnseignantCmdHdler> _logger;

        public AjouterEnseignantCmdHdler(ILogger<AjouterEnseignantCmdHdler> logger, IPointDaccess pointDaccess, IMapper mapper, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<ReponseDeRequette> Handle(AjouterEnseignantCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle : On Vas Essayer d'ajoutter Une nouvel enseignant  dans la Base de donnees  ");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDunEnseignantDto();
            var resultatValidation = await validateur.ValidateAsync(request.EnseignantAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid is false)
            {
                _logger.LogWarning(" Handle: les donnees entrer ne sont pas valides . la requettes n'aboutirra pas ");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Enseignant a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var enseignant = await _pointDaccess.RepertoireDenseignant.LireEnseignantParNumeroExterne(request.EnseignantAAjouterDto.NumeroExterne).ConfigureAwait(false);
                if (enseignant is not null)
                {
                    _logger.LogInformation(" Handle: Enseignant Exite deja !!! ");
                    reponse.Success = true;
                    reponse.Message = "L'Enseignant Existe deja dans la base de donnee ";
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    var personneACreer = _mapper.Map<Enseignant>(request.EnseignantAAjouterDto);
                    var result = await _pointDaccess.RepertoireDenseignant.Ajoutter(personneACreer);

                    if (result is null)
                    {
                        _logger.LogError(" Handle: Une Erreur Inconnu est Survenu:  la requettes n'a pas aboutti ");
                        reponse.Success = false;
                        reponse.Message = "Echec de Lajout dune Enseignant a la personne donc l'Id est notee dans le champs d'Id";
                        reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                    else
                    {
                        _logger.LogInformation(" Handle: LAjout de lenseignant a reussit !!! ");
                        reponse.Success = true;
                        reponse.Message = "Ajout de Enseignant Reussit";
                        reponse.Id = result.Id;
                        reponse.StatusCode = (int)HttpStatusCode.Created;
                    }
                }
            }
            return reponse;
        }
    }
}
