using JwtAuthExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiExample;

public class UsersDbContext:DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options):base(options)
    {
    }

    private DbSet<User> Users { get; set; }
}