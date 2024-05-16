using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.infraestructure.Configurations.Users;

public class User
{
    [Column("user_id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("idade")]
    public int Idade { get; set; }

    [Column("email")]
    public required string? Email { get; set; }

    [Column("passwordhash")]
    public byte[]? PasswordHash { get; set; }

    [Column("passwordsalt")]
    public byte[]? PasswordSalt { get; set; }

}