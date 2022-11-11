using MediatR;
using Gdc.Api.Features.Commandes.Niveaux;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gdc.Api.Modeles;
using MsCommun.Exceptions;
using Gdc.Api.Modeles;
using Gdc.Api.Repertoires.Contrats;

namespace Gdc.Api.Features.CommandHandlers.Niveaux
{
    public class SupprimerUnNiveauCmdHdler : IRequestHandler<SupprimerUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnNiveauCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnNiveauCmd request, CancellationToken cancellationToken)
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
