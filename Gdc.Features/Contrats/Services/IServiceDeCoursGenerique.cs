using Gdc.Features.Dtos.CoursGeneriques;
using MsCommun.Reponses;

namespace Gdc.Features.Contrats.Services
{
    public interface IServiceDeCoursGenerique
    {
        public Task<List<CoursGeneriqueDto>> LireTousLesCoursGeneriques();
        public Task<CoursGeneriqueDetailDto> LireUnCoursGenerique(Guid id);
        public Task<ReponseDeRequette> AjouterUnCoursGenerique(CoursGeneriqueACreerDto coursGeneriqueAAjouterDto);
        public Task<ReponseDeRequette> ModifierUnCoursGenerique(Guid id, CoursGeneriqueAModifierDto coursGeneriqueAModifierDto);
        public Task<ReponseDeRequette> SupprimerUnCoursGenerique(Guid id);
    }
}
