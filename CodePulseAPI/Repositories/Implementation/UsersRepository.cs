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

    public async Task<User> UpdateAsync(Guid id, User user)
    {
        var registro = await _dbContext.User.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (registro == null)
        {
            return null;
        }

        registro.NameOrEmail = user.NameOrEmail;
        registro.Password = user.Password;

        _dbContext.User.Update(registro);
        await _dbContext.SaveChangesAsync();

        return registro;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _dbContext.User.ToListAsync();
        foreach(var user in users)
        {
            user.Password = "Até parece que seria facil assim";
        }
        return users;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var user = await _dbContext.User.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _dbContext.User.Remove(user);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
