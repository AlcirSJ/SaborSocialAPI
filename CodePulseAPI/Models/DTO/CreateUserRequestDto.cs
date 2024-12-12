namespace CodePulseAPI.Models.DTO
{
    public class CreateUserRequestDto
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
