using MediatR;
using Gdc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gdc.Features.Core.BaseFactoryClass;
using MsCommun.Exceptions;
using Gdc.Features.Core.BaseFactoryClass;
using Gdc.Features.Core.Commandes.Niveaux;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Core.Handlers.Niveaux
{
    public class SupprimerUnNiveauCmdHdler : BaseCommandHandler<SupprimerUnNiveauCmd, ReponseDeRequette>
    {

        private readonly ILogger<SupprimerUnNiveauCmdHdler> _logger;

        public SupprimerUnNiveauCmdHdler(ILogger<SupprimerUnNiveauCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
             : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public override async Task<ReponseDeRequette> Handle(SupprimerUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id);

            if (niveau == null)
                throw new NotFoundException(nameof(Niveau), request.Id);

            if (niveau != null)
            {
                var resultat = await _pointDaccess.RepertoireDeNiveau.Supprimer(niveau);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'niveau d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet niveau 
                    await _mediator.Send(new SupprimerUnNiveauCmd { Id = niveau.Id }, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas d'niveau d'Id {request.Id}";
            }
            return response;
        }
    }
}
