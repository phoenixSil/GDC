using Gdc.Features.Dtos.Matieres;
using MsCommun.Reponses;

namespace Gdc.Features.Contrats.Services
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
