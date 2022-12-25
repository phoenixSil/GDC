using Gdc.Features.Dtos.Enseignants;
using MsCommun.Reponses;

namespace Gdc.Features.Contrats.Services
{
    public interface IServiceDenseignant
    {
        public Task<List<EnseignantDto>> LireTousLesEnseignants();
        public Task<List<EnseignantDto>> ListerTousLesEnseignantsProgrammerDansLintervalle(DateTime dateDeDebut, DateTime dateDeFin);
        public Task<EnseignantDetailDto> LireUnEnseignant(Guid id);
        public Task<ReponseDeRequette> AjouterUnEnseignant(EnseignantACreerDto personneAAjouterDto);
        public Task<ReponseDeRequette> ModifierUnEnseignant(Guid id, EnseignantAModifierDto personneAModifierDto);
        public Task<ReponseDeRequette> SupprimerUnEnseignant(Guid id);
        public Task<ReponseDeRequette> SupprimerParNumeroExterne(Guid mumeroExterne);
        public Task<EnseignantDto> LireEnseignantParNumeroExterne(Guid numeroExterne);
    }
}
