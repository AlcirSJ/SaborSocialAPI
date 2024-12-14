using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
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

    public async Task<Evento> UpdateByIdAsync(Guid id, CreateEventoRequestDto evento)
    {
        var registro = await _dbContext.Evento.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (registro == null)
        {
            return null;
        }

        registro.Name = evento.Name;
        registro.Person = evento.Person;
        registro.Date = evento.Date;
        registro.Location = evento.Location;
        registro.Description = evento.Description;
        registro.Identification = evento.Identification;
        registro.Ong = evento.Ong;
        registro.ValidationCode = evento.ValidationCode;
        registro.FoodType = evento.FoodType;
        registro.Kg = evento.Kg;

        _dbContext.Evento.Update(registro);
        await _dbContext.SaveChangesAsync();

        return registro;
    }
}
