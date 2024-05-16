using Microsoft.EntityFrameworkCore;
using Teste.infraestructure.Configurations.Users;

namespace Teste.infraestructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}