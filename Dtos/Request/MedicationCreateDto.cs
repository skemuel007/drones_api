using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace drones_api.Dtos.Request
{
    public class MedicationCreateDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Only letters, numbers, dashes and underscore allowed")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z0-9_]+$", ErrorMessage = "Only Uppercase letters, numbers and underscore allowed")]
        public string Code { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
