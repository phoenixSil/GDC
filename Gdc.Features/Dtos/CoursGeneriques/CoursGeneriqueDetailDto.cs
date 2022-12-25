
using Gdc.Features.Dtos.Matieres;
using Gdc.Domain.Modeles;

namespace Gdc.Features.Dtos.CoursGeneriques
{
    public class CoursGeneriqueDetailDto : BaseDto, ICoursGeneriqueDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public virtual List<MatiereDto> Matieres { get; set; }
    }
}
