using System.ComponentModel.DataAnnotations;

namespace CodePulseAPI.Models.DTO
{
    public class CreateUserRequestDto
    {
        [Required]
        [EmailAddress]
        public string NameOrEmail { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
