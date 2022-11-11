using MsCommun.Exceptions;
using Gdc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MediatR;
using Gdc.Api.Modeles;

namespace Gdc.Api.Features.Commandes.CoursGeneriques
{
    public class SupprimerUnCoursGeneriqueCmdHdler : IRequestHandler<SupprimerUnCoursGeneriqueCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnCoursGeneriqueCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }
        public async Task<ReponseDeRequette> Handle(SupprimerUnCoursGeneriqueCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();

            if (request.CoursGeneriqueId == Guid.Empty)
                throw new BadRequestException($"Id [{request.CoursGeneriqueId}] que vous avez entrez est null");

            var coursGenerique = await _pointDaccess.RepertoireDeCoursGenerique.Lire(request.CoursGeneriqueId);

            if (coursGenerique != null)
            {
                await _pointDaccess.RepertoireDeCoursGenerique.Supprimer(coursGenerique);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Suppression Reussit ";
                reponse.Id = request.CoursGeneriqueId;

                return reponse;
            }
            throw new NotFoundException(nameof(CoursGenerique), request.CoursGeneriqueId);
        }
    }
}
