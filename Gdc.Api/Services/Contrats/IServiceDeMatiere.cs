using Gdc.Api.Dtos.Matieres;
using MsCommun.Reponses;

namespace Gdc.Api.Services.Contrats
{
    public interface IServiceDeMatiere
    {
        public Task<List<MatiereDto>> LireToutesLesMatieres();
        public Task<MatiereDetailDto> LireUneMatiere(Guid id);
        public Task<ReponseDeRequette> AjouterUneMatiere(MatiereACreerDto personneAAjouterDto);
        public Task<ReponseDeRequette> ModifierUneMatiere(Guid id, MatiereAModifierDto personneAModifierDto);
        public Task<ReponseDeRequette> SupprimerUneMatiere(Guid id);
    }
}
