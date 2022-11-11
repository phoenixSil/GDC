using Gdc.Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gdc.Api.Dtos.CoursGeneriques
{
    public class CoursGeneriqueAModifierDto : BaseDto, ICoursGeneriqueDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
    }
}
