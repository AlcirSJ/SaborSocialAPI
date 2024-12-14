using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;

namespace CodePulseAPI.Repositories.Interface;

public interface IEventosRepository
{
    Task<Evento> CreateAsync(Evento evento);
    Task<IEnumerable<Evento>> GetAllAsync();
    Task<Evento?> GetByIdAsync(Guid id);
    Task<Evento> UpdateByIdAsync(Guid id, CreateEventoRequestDto evento);
    Task<bool> DeleteByIdAsync(Guid id);
}
