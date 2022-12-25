
using System.ComponentModel.DataAnnotations;

namespace Gdc.Features.Dtos.CoursGeneriques
{
    public class CoursGeneriqueACreerDto :  ICoursGeneriqueDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
    }
}
