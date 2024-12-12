using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface;

public interface IEventosRepository
{
    Task<Evento> CreateAsync(Evento evento);
    Task<IEnumerable<Evento>> GetAllAsync();
    Task<Evento?> GetByIdAsync(Guid id);
    Task<bool> DeleteByIdAsync(Guid id);
}
