using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Models.DTO;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Repositories.Implementation;

public class OrganizacaoRepository : IOrganizacaoRepository
{
    private readonly ApplicationDbContext _dbContext;
    public OrganizacaoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Organizacao> CreateAsync(Organizacao organizacao)
    {
        await _dbContext.Organizacaos.AddAsync(organizacao);
        await _dbContext.SaveChangesAsync();
        return organizacao;
    }

    public async Task<IEnumerable<Organizacao>> GetAllAsync()
    {
        return await _dbContext.Organizacaos.ToListAsync();
    }

    public async Task<Organizacao> GetByIdAsync(Guid id)
    {
        return await _dbContext.Organizacaos.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<Organizacao> UpdateByIdAsync(Guid id, Organizacao organizacao)
    {
        var registro = await _dbContext.Organizacaos.FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (registro == null)
        {
            return null;
        }

        registro.Name = organizacao.Name;
        registro.Address = organizacao.Address;
        registro.PhoneNumber = organizacao.PhoneNumber;
        registro.Email = organizacao.Email;
        registro.Cnpj = organizacao.Cnpj;       

        _dbContext.Organizacaos.Update(registro);
        await _dbContext.SaveChangesAsync();

        return registro;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {

        var organizacao = await _dbContext.Organizacaos.FindAsync(id);

        if (organizacao == null)
        {
            return false;
        }

        _dbContext.Organizacaos.Remove(organizacao);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
