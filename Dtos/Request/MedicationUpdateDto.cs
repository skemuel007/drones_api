using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace drones_api.Dtos.Request
{
    public class MedicationUpdateDto
    {
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Only letters, numbers, dashes and underscore allowed")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Only Uppercase letters, numbers and underscore allowed")]
        public string Code { get; set; }
        [Required]
        public decimal Weight { get; set; }
        public IFormFile Image { get; set; }
    }
}
