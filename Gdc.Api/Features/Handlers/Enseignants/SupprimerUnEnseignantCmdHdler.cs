using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Modeles;

namespace Gdc.Api.Features.Commandes.Enseignants
{
    public class SupprimerUnEnseignantCmdHdler : IRequestHandler<SupprimerUnEnseignantCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnEnseignantCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }
        public async Task<ReponseDeRequette> Handle(SupprimerUnEnseignantCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            var enseignant = await _pointDaccess.RepertoireDenseignant.Lire(request.EnseignantId);

            if(enseignant is null)
            {
                reponse.Success = true;
                reponse.Message = $"l'enseignant d\"Id [{request.EnseignantId}] n'existe pas dans la base :: coursDb";
                reponse.Id = request.EnseignantId;
                return reponse;

            } 
            else
            {
                await _pointDaccess.RepertoireDenseignant.Supprimer(enseignant);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.EnseignantId;

                return reponse;
            }
        }
    }
}
