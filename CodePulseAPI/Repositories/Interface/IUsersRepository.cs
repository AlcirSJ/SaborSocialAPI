using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface
{
    public interface IUsersRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(Guid id ,User user);
        Task<bool> AuthUser(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
