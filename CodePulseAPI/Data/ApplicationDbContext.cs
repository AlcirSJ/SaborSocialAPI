using CodePulseAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Evento> Evento { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Organizacao> Organizacaos { get; set; }

    }
}
