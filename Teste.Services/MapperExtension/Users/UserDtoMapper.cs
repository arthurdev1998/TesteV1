using Teste.Common.Dtos.Users;
using Teste.infraestructure.Configurations.Users;

namespace Teste.Services.MapperExtension.Users;

public static class UserDtoMapper
{
    public static UserDto MapToUserDto(User src)
    {
        return new UserDto
        {
            Id = src.Id,
            Name = src.Name,
            Email = src.Email
        };
    }

    public static List<UserDto> MapToUserDto(ICollection<User> src)
    {
        return src.Select(x => MapToUserDto(x)).ToList();
    }
}                                                                           