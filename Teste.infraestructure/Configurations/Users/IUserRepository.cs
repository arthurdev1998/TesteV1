namespace Teste.infraestructure.Configurations.Users;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers(bool asnotracking = true);
    public Task<User> GetUserById(int id, bool asnotracking = true);
    public Task<User> UpdateUser(User obj, bool asnotrcking = true);
    public Task<User> CreateUser(User obj, bool asnotracking = true);
    public void RemoveUser(User obj);   
}