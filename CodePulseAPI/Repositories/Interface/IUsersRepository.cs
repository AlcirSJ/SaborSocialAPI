using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface
{
    public interface IUsersRepository
    {
        Task<User> CreateAsync(User user);

        Task<bool> AuthUser(User user);
       
    }
}
