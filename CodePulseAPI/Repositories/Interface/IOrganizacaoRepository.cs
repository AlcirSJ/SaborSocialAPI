using CodePulseAPI.Models.Domain;

namespace CodePulseAPI.Repositories.Interface;

public interface IOrganizacaoRepository
{
    Task<Organizacao> CreateAsync(Organizacao organizacao);
    Task<IEnumerable<Organizacao>> GetAllAsync();
    Task<Organizacao> GetByIdAsync(Guid id);
    Task<Organizacao> UpdateByIdAsync(Guid id, Organizacao organizacao);
    Task<bool> DeleteByIdAsync(Guid id);
}
