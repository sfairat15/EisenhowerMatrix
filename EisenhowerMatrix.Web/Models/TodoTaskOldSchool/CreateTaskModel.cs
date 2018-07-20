using System.ComponentModel.DataAnnotations;

namespace EisenhowerMatrix.Web.Models.TodoTaskOldSchool
{
    public class CreateTaskModel
    {
        [Required]
        [MaxLength(1024)]
        public string Name { get; set; }

        [Range(0, 10, ConvertValueInInvariantCulture = true, ErrorMessage = "Value should be in {1}-{2} range")]
        public double Urgency { get; set; }

        [Range(0, 10, ConvertValueInInvariantCulture = true, ErrorMessage = "Value should be in {1}-{2} range")]
        public double Importance { get; set; }
    }
}
