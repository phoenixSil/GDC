using Gdc.Api.Dtos;
using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Modeles;

namespace Gdc.Api.Dtos.CoursGeneriques
{
    public class CoursGeneriqueDetailDto : BaseDto, ICoursGeneriqueDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public virtual List<MatiereDto> Matieres { get; set; }
    }
}
