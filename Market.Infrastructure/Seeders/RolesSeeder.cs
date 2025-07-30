using Market.Domain.Entities;
using Market.Infrastructure.Context;

namespace Market.Infrastructure.Seeders;

public class RolesSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext)
    {
        var roles = new List<Role>
        {
            new Role { Name = "Admin" },
            new Role { Name = "User" },
            new Role { Name = "Farmer" },
        };

        foreach (var role in roles)
        {
            if (!dbContext.Roles.Any(r => r.Name == role.Name))
            {
                dbContext.Roles.Add(role);
            }
        }

        await dbContext.SaveChangesAsync();
    }
}