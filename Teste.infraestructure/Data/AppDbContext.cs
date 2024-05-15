using Microsoft.EntityFrameworkCore;
using Teste.infraestructure.Configurations.Pessoa;

namespace Teste.infraestructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas { get; set; }
}