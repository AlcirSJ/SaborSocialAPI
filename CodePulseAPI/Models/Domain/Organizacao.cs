using System.Reflection.Metadata.Ecma335;

namespace CodePulseAPI.Models.Domain
{
    public class Organizacao
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }

    }
}
