namespace CodePulseAPI.Models.Domain;

public class User
{
    public Guid Id { get; set; }
    public string NameOrEmail { get; set; }
    public string Password { get; set; }

}
