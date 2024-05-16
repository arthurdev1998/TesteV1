using System.Security.Cryptography;
using System.Text;
using Teste.Common.Dtos.Users;
using Teste.Common.Messages;
using Teste.infraestructure.Configurations.Users;
using Teste.infraestructure.UnitofWorks;
using Teste.Services.MapperExtension.Users;

namespace Teste.Services.Services.Users;

public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<ServiceResult<UserDto>> ExecuteAsync(UserInsertDto userDto)
    {
        if (string.IsNullOrEmpty(userDto.Password))
            return new ServiceResult<UserDto>("Senha nao pode ser nula ou vazia");

        var entity = userDto.MapToNew();

        using var hmac = new HMACSHA512();
        var bytes = Encoding.UTF8.GetBytes(userDto.Password);
        byte[] passwordHash = hmac.ComputeHash(bytes);
        byte[] passwordSalt = hmac.Key;

        entity.PasswordHash = passwordHash;
        entity.PasswordSalt = passwordSalt;

        await _userRepository.CreateUser(entity);
        await _unitOfWork.SaveChangesAsync();

        return new ServiceResult<UserDto>(entity.MapTo<UserDto>());
    }
}