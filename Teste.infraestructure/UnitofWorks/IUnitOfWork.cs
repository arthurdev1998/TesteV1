namespace Teste.infraestructure.UnitofWorks;

public interface IUnitOfWork : IDisposable
{
    public Task SaveChangesAsync();       
}