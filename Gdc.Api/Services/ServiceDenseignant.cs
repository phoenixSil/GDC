using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Services.Contrats;
using MediatR;
using MsCommun.Reponses;
using Gdc.Api.Features.Commandes.Enseignants;
using AutoMapper;

namespace Gdc.Api.Services
{
    public class ServiceDenseignant: IServiceDenseignant
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ServiceDenseignant(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<ReponseDeRequette> AjouterUnEnseignant(EnseignantACreerDto enseignantDto)
        {
            var response = await _mediator.Send(new AjouterEnseignantCmd { EnseignantAAjouterDto = enseignantDto });
            return response;
        }

        public async Task<EnseignantDetailDto> LireUnEnseignant(Guid enseignantId)
        {
            var response = await _mediator.Send(new LireUnEnseignantCmd { EnseignantId = enseignantId });
            return response;
        }

        public async Task<List<EnseignantDto>> LireTousLesEnseignants()
        {
            var response = await _mediator.Send(new LireTousLesEnseignantsCmd { });
            return response;
        }

        public async Task<ReponseDeRequette> ModifierUnEnseignant(Guid enseignantId, EnseignantAModifierDto enseignantDto)
        {
            var response = await _mediator.Send(new ModifierUnEnseignantCmd { EnseignantId = enseignantId, EnseignantAModifierDto = enseignantDto });
            return response;
        }


        public async Task<ReponseDeRequette> SupprimerUnEnseignant(Guid enseignantId)
        {
            var response = await _mediator.Send(new SupprimerUnEnseignantCmd { EnseignantId = enseignantId });
            return response;
        }

        public Task<List<EnseignantDto>> ListerTousLesEnseignantsProgrammerDansLintervalle(DateTime dateDeDebut, DateTime dateDeFin)
        {
           throw new NotImplementedException();
        }

        public async Task<ReponseDeRequette> SupprimerParNumeroExterne(Guid mumeroExterne)
        {
            var response = new ReponseDeRequette();

            var enseignant = await _mediator.Send(new LireEnseignantParNumeroExterneCmd {  NumeroExterne = mumeroExterne })
                        .ConfigureAwait(false);
            if(enseignant != null)
            {
                return await _mediator.Send(new SupprimerUnEnseignantCmd { EnseignantId = enseignant.Id })
                       .ConfigureAwait(false);
            } else
            {
                response.Success = true;
                response.Message = $"Cet Enseignant avec pour NumeroExterne [{mumeroExterne}] n'Existe pa dans Gdc ";
                return response;
            }
           
        }

        public async Task<ReponseDeRequette> ModifierUnEnseignantParNumeroExterne(Guid id, EnseignantAModifierDeGdeDto enseignantAModifierDto)
        {
            var dto = new EnseignantAModifierDto
            {
                Nom = enseignantAModifierDto.Nom,
                Prenom = enseignantAModifierDto.Prenom,
                NumeroExterne = enseignantAModifierDto.NumeroExterne
            };

            var enseignant = await _mediator.Send(new LireEnseignantParNumeroExterneCmd { NumeroExterne = id })
                        .ConfigureAwait(false);
            if (enseignant != null)
            {
                dto.Id = enseignant.Id;
                return await _mediator.Send(new ModifierUnEnseignantCmd { EnseignantId = enseignant.Id, EnseignantAModifierDto = dto })
                       .ConfigureAwait(false);
            }
            else
            {
                return await _mediator.Send(new AjouterEnseignantCmd { EnseignantAAjouterDto = _mapper.Map<EnseignantACreerDto>(dto) })
                       .ConfigureAwait(false);
            }
        }
    }
}
