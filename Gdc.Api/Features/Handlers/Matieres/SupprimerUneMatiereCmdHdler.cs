using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Modeles;

namespace Gdc.Api.Features.Commandes.Matieres
{
    public class SupprimerUneMatiereCmdHdler : IRequestHandler<SupprimerUneMatiereCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUneMatiereCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }
        public async Task<ReponseDeRequette> Handle(SupprimerUneMatiereCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.MatiereId == Guid.Empty)
                throw new BadRequestException($"Id [{request.MatiereId}] que vous avez entrez est null");

            var matiere = await _pointDaccess.RepertoireDeMatiere.Lire(request.MatiereId);

            if (matiere != null)
            {
                await _pointDaccess.RepertoireDeMatiere.Supprimer(matiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.MatiereId;

                return reponse;
            }
            throw new NotFoundException(nameof(Matiere), request.MatiereId);
        }
    }
}
