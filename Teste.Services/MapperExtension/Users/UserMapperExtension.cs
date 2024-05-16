using Teste.Common.Dtos.Users;
using Teste.infraestructure.Configurations.Users;

namespace Teste.Services.MapperExtension.Users;

public static class UserMapperExtension
{
    public static T MapTo<T>(this User src)
    {
        var user = new List<User> { src };

        return user.MapTo<IList<T>>().First();
    }

    public static T MapTo<T>(this ICollection<User> src)
    {
        var interfaceOfGeneric = typeof(T).GetInterfaces();

        if (interfaceOfGeneric.Any(x => x == typeof(ICollection<User>)))
        {
            return (T)(object)UserDtoMapper.MapToUserDto(src);
        }

        throw new Exception($"Not Implemented Interface{typeof(T)}");
    }

    public static User MapToNew(this UserInsertDto dto)
    {
        return new User()
        {
            Name = dto.Name,
            Email = dto.Email,
        };
    }
}
