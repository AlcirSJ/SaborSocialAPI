using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Repositories.Implementation;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.User.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<bool> AuthUser(User usuario)
    {
      
        var user = await _dbContext.User.FirstOrDefaultAsync(x => x.NameOrEmail.Equals(usuario.NameOrEmail));

        if( user is null)
        {
            return false;
        }

        return user.Password == usuario.Password ? true : false ;
    }


}
