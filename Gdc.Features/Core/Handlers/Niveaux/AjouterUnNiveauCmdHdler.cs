using AutoMapper;
using MediatR;
using Gdc.Features.Core.BaseFactoryClass;
using MsCommun.Reponses;
using Gdc.Features.Contrats.Repertoires;
using Gdc.Features.Dtos.Niveaux.Validations;
using Gdc.Features.Core.Commandes.Niveaux;
using Gdc.Features.Core.Handlers.CoursGeneriques;
using Microsoft.Extensions.Logging;
using Gdc.Domain.Modeles;
using System.Net;

namespace Gdc.Features.Core.Handlers.Niveaux
{
    public class AjouterUneNiveauAUnePersonneCmdHdler : BaseCommandHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {

        private readonly ILogger<AjouterUneNiveauAUnePersonneCmdHdler> _logger;

        public AjouterUneNiveauAUnePersonneCmdHdler(ILogger<AjouterUneNiveauAUnePersonneCmdHdler> logger, IMapper mapper, IPointDaccess pointDaccess, IMediator mediator)
             : base(pointDaccess, mediator, mapper)
        {
            _logger= logger;
        }
        public override async Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto();
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto);

            if (resultatValidation.IsValid is false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                reponse.StatusCode = (int)HttpStatusCode.BadRequest; 
            }
            else
            {
                var niveauACreer = _mapper.Map<Niveau>(request.NiveauAAjouterDto);
                niveauACreer.Id = Guid.NewGuid();
                var result = await _pointDaccess.RepertoireDeNiveau.Ajoutter(niveauACreer);

                if (result is null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Niveau";
                    reponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Niveau Reussit";
                    reponse.Id = result.Id;
                    reponse.StatusCode = (int)HttpStatusCode.Created;
                }
            }

            return reponse;
        }
    }
}
