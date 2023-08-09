using JwtAuthExample.Enums;

namespace JwtAuthExample.Models;

public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public static User[] GetArrayUsers()
    {
        return new User[]
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Login = "superuser",
                Password = "dodp1"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                Login = "ruser",
                Password = "password"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                Login = "string",
                Password = "string"
            },
            
        };
    }
}