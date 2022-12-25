using Gdc.Features.Dtos.Niveaux;
using MsCommun.Reponses;

namespace Gdc.Features.Contrats.Services
{
    public interface IServiceDeNiveau
    {
        public Task<List<NiveauDto>> LireTousLesNiveaus();
        public Task<ReponseDeRequette> AjouterUnNiveau(NiveauACreerDto  niveauAAjouter);
        public Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId);
        public Task<NiveauDetailDto> LireDetailDunNiveau(Guid id);
        public Task<ReponseDeRequette> ModifierUnNiveau(Guid niveauId, NiveauAModifierDto niveauAModifierDto);
        public Task<NiveauDetailDto> LireNiveauParNumeroExterne(Guid numeroExterne);
    }
}
