using Gdc.Api.Dtos.Niveaux;
using MsCommun.Reponses;

namespace Gdc.Api.Services.Contrats
{
    public interface IServiceDeNiveau
    {
        public Task<List<NiveauDto>> LireTousLesNiveaus();
        public Task<ReponseDeRequette> AjouterUnNiveau(NiveauGdcACreerDto  niveauAAjouter);
        public Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId);
        public Task<NiveauDetailDto> LireDetailDunNiveau(Guid id);
        public Task<ReponseDeRequette> ModifierUnNiveau(Guid niveauId, NiveauAModifierDto niveauAModifierDto);
    }
}
