using AutoMapper;
using MediatR;
using Gdc.Api.Features.Commandes.Niveaux;
using Gdc.Api.Modeles;
using MsCommun.Reponses;
using Gdc.Api.Repertoires.Contrats;
using Gdc.Api.Dtos.Niveaux.Validations;

namespace Gdc.Api.Features.CommandHandlers.Niveaux
{
    public class AjouterUneNiveauAUnePersonneCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneNiveauAUnePersonneCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto();
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var niveauACreer = _mapper.Map<Niveau>(request.NiveauAAjouterDto);
                niveauACreer.Id = Guid.NewGuid();
                var result = await _pointDaccess.RepertoireDeNiveau.Ajoutter(niveauACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Personne Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
