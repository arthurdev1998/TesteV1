
using Microsoft.EntityFrameworkCore;
using Teste.infraestructure.Data;

namespace Teste.infraestructure.Configurations.Users;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User obj, bool asnotracking = true)
    {
        await _context.Users.AddAsync(obj);
        return obj;
    }

    public async Task<List<User>> GetAllUsers(bool asnotracking = true)
    {
        return asnotracking ? await _context.Users.AsNoTracking().ToListAsync() :
        await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(int id, bool asnotracking = true)
    {
        return asnotracking ?
        await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) :
        await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void RemoveUser(User obj)
    {
        _context.Remove(obj);
    }

    public async Task<User> UpdateUser(User obj, bool asnotrcking = true)
    {
        await _context.AddAsync(obj);
        return obj;
    }
}