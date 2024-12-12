using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodePulseAPI.Repositories.Implementation;

public class EventosRepository : IEventosRepository
{
    private readonly ApplicationDbContext _dbContext;
    public EventosRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Evento> CreateAsync(Evento evento)
    {
        await _dbContext.Evento.AddAsync(evento);
        await _dbContext.SaveChangesAsync();
        return evento;
    }

    public async Task<IEnumerable<Evento>> GetAllAsync()
    {
        return await _dbContext.Evento.ToListAsync();
    }

    public async Task<Evento?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Evento.FirstOrDefaultAsync(x => x.Id.Equals(id));

    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        
        var evento = await _dbContext.Evento.FindAsync(id);

        if (evento == null)
        {           
            return false;
        }
       
        _dbContext.Evento.Remove(evento);
        await _dbContext.SaveChangesAsync();

        
        return true;
    }
}
