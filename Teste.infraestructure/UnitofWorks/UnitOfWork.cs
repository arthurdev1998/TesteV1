
using Teste.infraestructure.Data;

namespace Teste.infraestructure.UnitofWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose() => _db.Dispose();
}