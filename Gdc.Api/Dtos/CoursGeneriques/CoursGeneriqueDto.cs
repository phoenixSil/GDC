using Gdc.Api.Dtos;

namespace Gdc.Api.Dtos.CoursGeneriques
{
    public class CoursGeneriqueDto: BaseDto, ICoursGeneriqueDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
    }
}
